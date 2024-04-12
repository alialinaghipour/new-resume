namespace Presentation.Configs.Routing;

public static class Startup
{
    internal static IServiceCollection AddRoutingInfoApi(
        this IServiceCollection services)
    {
        services.AddRouting();
        services.AddControllers();
        services.AddHttpContextAccessor();

        return services;
    }
    

    internal static IApplicationBuilder UseRoutingInfoApi(
        this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
            endpoints.MapControllers());
        return app;
    }
    
    internal static IApplicationBuilder UseRoutingInfoWeb(
        this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name : "areas",
                pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        });
        
        return app;
    }
}