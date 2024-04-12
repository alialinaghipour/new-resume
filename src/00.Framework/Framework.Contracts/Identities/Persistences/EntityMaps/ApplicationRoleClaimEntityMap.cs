namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class
    ApplicationRoleClaimEntityMap : IEntityTypeConfiguration<
        ApplicationRoleClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {
        builder.ToTable("ApplicationRoleClaims");
    }
}