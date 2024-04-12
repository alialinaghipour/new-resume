namespace Presentation.Configs.Services;

public class AutofacBusinessModule : Module
{
    private readonly IConfiguration _configuration;

    public AutofacBusinessModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void Load(ContainerBuilder container)
    {
        
        var frameworkAssembly = typeof(FrameworkAssembly).Assembly;
        var repositoryAssembly = typeof(PersistenceEfAssembly).Assembly;
        var serviceAssembly = typeof(ServiceAssembly).Assembly;
        
        container.RegisterAssemblyTypes(
                frameworkAssembly,
                repositoryAssembly,
                serviceAssembly)
            .AssignableTo<IScope>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        container.RegisterAssemblyTypes(
                serviceAssembly,
                frameworkAssembly,
                repositoryAssembly)
            .AssignableTo<ISingleton>()
            .AsImplementedInterfaces()
            .SingleInstance();

        var connectionString = _configuration
            .GetValue<string>("dbConnectionStrings")!;
        container.RegisterType<ApplicationDbContext>()
            .WithParameter("dbConnectionStrings", connectionString)
            .AsSelf()
            .InstancePerLifetimeScope();

        base.Load(container);
    }
}