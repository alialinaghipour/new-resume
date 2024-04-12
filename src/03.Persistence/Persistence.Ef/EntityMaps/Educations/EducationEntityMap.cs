namespace Persistence.Ef.EntityMaps.Educations;

public class EducationEntityMap : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations");

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