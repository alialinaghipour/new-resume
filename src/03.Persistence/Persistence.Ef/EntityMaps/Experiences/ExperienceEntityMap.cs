namespace Persistence.Ef.EntityMaps.Experiences;

public class ExperienceEntityMap : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences");

        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Order)
            .IsRequired();
        builder.Property(_ => _.StartDate)
            .IsRequired();
        builder.Property(_ => _.EndDate)
            .IsRequired();
        builder.Property(_ => _.Description)
            .IsRequired();
        builder.Property(_ => _.Title)
            .IsRequired();
    }
}