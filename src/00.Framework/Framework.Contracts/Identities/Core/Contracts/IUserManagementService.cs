namespace Framework.Contracts.Identities.Core.Contracts;

public interface IUserManagementService : IScope
{
    Task<ApplicationUser> Create(ApplicationUser user, string password);
    Task<ApplicationUser?> FindByUsername(string username);
    bool VerifyHashedPassword(ApplicationUser applicationUser, string password);
    Task<string> GetToken(string username,string password);
    Task<IList<Claim>> GetClaimsAsync(ApplicationUser applicationUser);
    Task<IList<string>> GetRolesAsync(ApplicationUser applicationUser);
    Task SignIn(ApplicationUser user,bool isPersistent = true);
    bool IsSignIn();
    Task<ApplicationUser> LoginPassword(string userName, string password);
    Task PasswordSignIn(PasswordSignInDto dto);
    string? GetUserName();
    string? GetUserId();
    Task SignOut();
}