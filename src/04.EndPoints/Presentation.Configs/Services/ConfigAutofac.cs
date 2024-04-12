
namespace Presentation.Configs.Services;

public static class ConfigAutofac
{
   public static ConfigureHostBuilder AddAutofacConfigs(
      this ConfigureHostBuilder builder,
      IConfiguration configuration)
   {
      builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
      builder.ConfigureContainer<ContainerBuilder>(b =>
         b.RegisterModule(new AutofacBusinessModule(configuration))
      );
      return builder;
   }
}