namespace Framework.Contracts.Identities.Persistences.EntityMaps;

internal class
    ApplicationUserClaimEntityMap : IEntityTypeConfiguration<
        ApplicationUserClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder.ToTable("ApplicationUserClaims");
    }
}