namespace Framework.Contracts.UserIdentities;

public static class Startup
{
    public static IServiceCollection AddUserInfoIdentity(
        this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }
}