namespace Framework.Contracts.TokenServices;

public interface ITokenService : IScope
{
    string Generate(
        IEnumerable<Claim> userClaims, 
        IEnumerable<string> userRoles, 
        string applicationUserId);
    string GenerateRefreshToken();
    DateTime GetRefreshTokenExpiryTime();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}