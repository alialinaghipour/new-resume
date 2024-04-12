namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class ApplicationUserEntityMap 
    : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedNever();

        builder.Property(_ => _.UserName)
            .HasMaxLength(50);

        builder.Property(_ => _.NormalizedUserName)
            .HasMaxLength(50);

        builder.Property(_ => _.Email).IsUnicode(false)
            .IsRequired(false);
        builder.Property(_ => _.NormalizedEmail)
            .IsRequired(false);
        builder.Property(_ => _.PhoneNumber)
            .IsRequired(false);
    }
}