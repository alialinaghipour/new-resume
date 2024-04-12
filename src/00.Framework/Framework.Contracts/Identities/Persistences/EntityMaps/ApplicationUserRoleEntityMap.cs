namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class
    ApplicationUserRoleEntityMap : IEntityTypeConfiguration<
        ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.ToTable("ApplicationUserRoles");
    }
}