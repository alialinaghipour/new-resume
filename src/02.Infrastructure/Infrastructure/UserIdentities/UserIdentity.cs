using Framework.Contracts;
using Framework.Contracts.UserIdentities;

namespace Infrastructure.UserIdentities;

public class UserIdentity : IUserIdentity
{
    private readonly IHttpContextAccessor _accessor;

    public UserIdentity(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public ClaimsPrincipal GetUserClaimsPrincipal()
    {
        return _accessor.HttpContext!.User;
    }

    public string? UserName => GetUserName();
    public string? UserId => GetUserId();
    
    private string? GetUserName()
    {
        return _accessor.HttpContext?.User.Claims
            .FirstOrDefault(_ => _.Type == ClaimTypes.Name)?.Value;
    }
    
    private string? GetUserId()
    {
        return _accessor.HttpContext?.User.Claims
            .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}