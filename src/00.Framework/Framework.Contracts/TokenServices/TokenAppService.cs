namespace Framework.Contracts.TokenServices;

public class TokenAppService : ITokenService
{
    private readonly JwtBearerTokenConfig _jwtBearerTokenConfig;

    public TokenAppService(JwtBearerTokenConfig jwtBearerTokenConfig)
    {
        _jwtBearerTokenConfig = jwtBearerTokenConfig;
    }

    public string Generate(
        IEnumerable<Claim> userClaims,
        IEnumerable<string> userRoles,
        string applicationUserId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtBearerTokenConfig.SecretKey);

        var tokenClaims = new ClaimsIdentity();
        tokenClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, applicationUserId));

        WriteUserRolesToTokenClaims(ref tokenClaims, userRoles);
        WriteUserClaimsToTokenClaims(ref tokenClaims, userClaims);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = tokenClaims,
            Expires = DateTime.UtcNow.AddSeconds(_jwtBearerTokenConfig.ExpiryTimeInSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Audience = _jwtBearerTokenConfig.Audience,
            Issuer = _jwtBearerTokenConfig.Issuer
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public DateTime GetRefreshTokenExpiryTime()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
    
    private static void WriteUserClaimsToTokenClaims(
        ref ClaimsIdentity tokenClaims, 
        IEnumerable<Claim> userClaims)
    {
        foreach (var claim in userClaims)
        {
            tokenClaims.AddClaim(new Claim(claim.Type, claim.Value));
        }
    }

    private static void WriteUserRolesToTokenClaims(
        ref ClaimsIdentity tokenClaims, 
        IEnumerable<string> userRoles)
    {
        foreach (var role in userRoles)
        {
            tokenClaims.AddClaim(new Claim(ClaimTypes.Role, role));
        }
    }
}