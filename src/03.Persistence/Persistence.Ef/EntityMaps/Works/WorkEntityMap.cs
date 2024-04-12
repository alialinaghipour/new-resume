namespace Persistence.Ef.EntityMaps.Works;

public class WorkEntityMap : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.ToTable("Works");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedOnAdd();
        builder.Property(entity => entity.Icon)
            .IsRequired();
        builder.Property(entity => entity.Title)
            .IsRequired();
        builder.Property(entity => entity.Description)
            .IsRequired();
        builder.Property(entity => entity.ColumnLg)
            .IsRequired();
        builder.Property(entity => entity.Order)
            .IsRequired();
    }
}