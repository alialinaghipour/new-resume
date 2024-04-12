using Framework.Contracts.Identities.Persistences;
using Framework.Contracts.TokenServices;

namespace Framework.Contracts.Identities.Configs;

public static class Startup
{
    public static IServiceCollection AddIdentityFromFramework(
        this IServiceCollection services)
    {

        services
            .AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireDigit = false;
                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = false;
            }).AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();
        
        return services;
    }
    
    public static IServiceCollection AddAuthenticationFromFrameworkForApi(
        this IServiceCollection services,
        IConfiguration config)
    {
        var jwtSection = config.GetSection(nameof(TokenSettings));
        services.Configure<TokenSettings>(jwtSection);
        var jwtBearerTokenSettings = jwtSection.Get<TokenSettings>();
        var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings!.SecretKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.Audience = jwtBearerTokenSettings.Audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtBearerTokenSettings.Issuer,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
    
    public static IServiceCollection AddAuthenticationWeb(
        this IServiceCollection services,
        string loginPath = "/Login",
        string logoutPath = "/Logout")
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme= CookieAuthenticationDefaults.AuthenticationScheme;

        }).AddCookie(options =>
        {
            options.LoginPath = loginPath;
            options.LogoutPath = logoutPath;
            options.ExpireTimeSpan=TimeSpan.FromMinutes(43200);

        });

        return services;
    }
}