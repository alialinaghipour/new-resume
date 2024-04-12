namespace Persistence.Ef.EntityMaps.Informations;

public class InformationEntityMap : IEntityTypeConfiguration<Information>
{
    public void Configure(EntityTypeBuilder<Information> builder)
    {
        builder.ToTable("Informations");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id)
            .ValueGeneratedOnAdd();
    }
}