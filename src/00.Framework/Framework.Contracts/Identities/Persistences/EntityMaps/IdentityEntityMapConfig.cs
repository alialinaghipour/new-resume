namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public static class IdentityEntityMapConfig
{
    public static void ApplyIdentityEntityMap(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationUserEntityMap).Assembly);
    }
}