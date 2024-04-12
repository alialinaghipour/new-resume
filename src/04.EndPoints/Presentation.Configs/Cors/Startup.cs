namespace Presentation.Configs.Cors;

public static class Startup
{
    private const string CorsPolicy = nameof(CorsPolicy);

    public static IServiceCollection AddCorsConfigs(
        this IServiceCollection services)
    {
        return services.AddCors(opt =>
            opt.AddPolicy(CorsPolicy, policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));
    }

    public static IApplicationBuilder UseCorsConfigs(
        this IApplicationBuilder app)
    {
        return app.UseCors(CorsPolicy);
    }
}