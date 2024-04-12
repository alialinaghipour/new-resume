namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class ApplicationUserVerificationCodeEntityMap 
    : IEntityTypeConfiguration<ApplicationUserVerificationCode>
{
    public void Configure(EntityTypeBuilder<ApplicationUserVerificationCode> builder)
    {
        builder.ToTable("ApplicationUserVerificationCodes");
    }
}