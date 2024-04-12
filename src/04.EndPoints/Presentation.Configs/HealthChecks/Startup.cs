namespace Presentation.Configs.HealthChecks;

public static class Startup
{
    public static IServiceCollection AddHealthChecksConfigs(
        this IServiceCollection services)
    {
        services.AddHealthChecks();

        return services;
    }
}