namespace Framework.Contracts.TokenServices;

public static class Startup
{
    public static IServiceCollection AddTokenService(
        this IServiceCollection service,
        IConfiguration  config)
    {
        var jwt = new JwtBearerTokenConfig();
        config.Bind(nameof(JwtBearerTokenConfig), jwt);
        service.AddScoped<ITokenService, TokenAppService>(t => new TokenAppService(jwt));
        return service;
    }
}