namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class
    ApplicationUserLoginEntityMap : IEntityTypeConfiguration<
        ApplicationUserLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        builder.ToTable("ApplicationUserLogins");
    }
}