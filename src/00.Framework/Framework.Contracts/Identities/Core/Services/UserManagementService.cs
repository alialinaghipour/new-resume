using Framework.Contracts.Identities.Core.Contracts;
using Framework.Contracts.Identities.Core.Exceptions;
using Framework.Contracts.TokenServices;
using Framework.Contracts.UserIdentities;

namespace Framework.Contracts.Identities.Core.Services;

public class UserManagementService : IUserManagementService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserIdentity _userIdentity;

    public UserManagementService(
        UserManager<ApplicationUser> userManager,
        ITokenService tokenService,
        SignInManager<ApplicationUser> signInManager,
        IUserIdentity userIdentity)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userIdentity = userIdentity;
    }

    public async Task<ApplicationUser> Create(ApplicationUser user, string password)
    {
        if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
        {
            user.PhoneNumber =
                user.PhoneNumber!.TrimStart(new[] { '0' });
        }

        var result = await _userManager.CreateAsync(
            user,
            password);

        // duplicate email
        // duplicate phone Number
        //duplicate userName

        if (!result.Succeeded)
        {
            if (result.Errors.Any(_ => _.Code == UserManagementError.DuplicateUserName))
            {
                throw new DuplicateUserNameException();
            }

            if (result.Errors.Any(_ => _.Code == UserManagementError.PasswordRequiresUniqueChars))
            {
                throw new PasswordRequiresUniqueCharsException();
            }

            if (result.Errors.Any(_ => _.Code == UserManagementError.PasswordTooShort))
            {
                throw new PasswordTooShortException();
            }

            if (result.Errors.Any(_ => _.Code == UserManagementError.DuplicateEmail))
            {
                throw new DuplicateEmailException();
            }

            if (result.Errors.Any(_ => _.Code == UserManagementError.InvalidEmail))
            {
                throw new InvalidEmailException();
            }

            if (result.Errors.Any(_ => _.Code == UserManagementError.InvalidUserName))
            {
                throw new InvalidUserNameException();
            }

            throw new CreateUserFailedException();
        }


        return user;
    }

    public async Task<ApplicationUser?> FindByUsername(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<IList<Claim>> GetClaimsAsync(
        ApplicationUser applicationUser)
    {
        return await _userManager.GetClaimsAsync(applicationUser);
    }

    public async Task<IList<string>> GetRolesAsync(
        ApplicationUser applicationUser)
    {
        return await _userManager.GetRolesAsync(applicationUser);
    }

    public async Task SignIn(ApplicationUser user, bool isPersistent = true)
    {
        await _signInManager.SignInAsync(user, true);
    }

    public bool IsSignIn()
    {
        var userClaimsPrincipal =  _userIdentity.GetUserClaimsPrincipal();
        return _signInManager.IsSignedIn(userClaimsPrincipal);
    }

    public async Task<ApplicationUser> LoginPassword(string userName, string password)
    {
        var user =await _userManager.FindByNameAsync(userName);
        switch (user)
        {
            case null:
                throw new ApplicationUserNotFoundException();
            case { EmailConfirmed: false, Email: not null }:
                throw new YourEmailHasNotBeenActivatedException();
            case { PhoneNumberConfirmed: false, PhoneNumber: not null }:
                throw new YourPhoneNumberHasNotBeenActivatedException();
        }

        var verifyPassword = VerifyHashedPassword(user, password);
        if (!verifyPassword)
            throw new WrongUsernameOrPasswordException();

        return user;
    }

    public async Task PasswordSignIn(PasswordSignInDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(
            dto.UserName,
            dto.Password,
            dto.RememberMe,
            dto.LockoutOnFailure);

        if (result.IsLockedOut)
            throw new YourAccountIsLockedException();
        if (!result.Succeeded)
            throw new SignInFailedException();
    }

    public string? GetUserName()
    {
        return _userIdentity.UserName;
    }

    public string? GetUserId()
    {
        return _userIdentity.UserId;
    }

    public async Task SignOut()
    {
        await _signInManager.SignOutAsync();
    }

    public bool VerifyHashedPassword(ApplicationUser user, string password)
    {
        var passwordVerifiedResult =
            _userManager.PasswordHasher.VerifyHashedPassword(
                user,
                user!.PasswordHash!,
                password);

        return passwordVerifiedResult == PasswordVerificationResult.Success;
    }

    public async Task<string> GetToken(string username, string password)
    {
        var applicationUser = await FindByUsername(username);
        if (applicationUser == null)
            throw new WrongUsernameOrPasswordException();
        VerifyHashedPassword(applicationUser, password);

        var claims = await GetClaimsAsync(applicationUser);
        var roles = await GetRolesAsync(applicationUser);

        return _tokenService.Generate(
            claims, roles, applicationUser.Id);
    }
}