namespace Framework.Contracts.UserIdentities;

public interface IUserIdentity : IScope
{
    ClaimsPrincipal GetUserClaimsPrincipal();
    string? UserName{ get;}
    string? UserId{ get;}
}