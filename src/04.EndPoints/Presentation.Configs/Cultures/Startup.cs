namespace Presentation.Configs.Cultures;

public static class Startup
{
    public static IApplicationBuilder UseCultureConfigs(
        this IApplicationBuilder app)
    {
        CultureManagement.Culture();
        return app;
    }
}