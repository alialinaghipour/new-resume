namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class
    ApplicationRoleEntityMap : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("ApplicationRoles");
    }
}