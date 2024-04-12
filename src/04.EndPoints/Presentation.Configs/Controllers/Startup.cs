namespace Presentation.Configs.Controllers;

public static class Startup
{
    public static IServiceCollection AddControllersFroMvc(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        return services;
    }
}