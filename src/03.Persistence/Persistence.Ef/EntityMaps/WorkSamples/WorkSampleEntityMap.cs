namespace Persistence.Ef.EntityMaps.WorkSamples;

public class WorkSampleEntityMap : IEntityTypeConfiguration<WorkSample>
{
    public void Configure(EntityTypeBuilder<WorkSample> builder)
    {
        builder.ToTable("WorkSamples");
        
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();

        builder.HasOne(_ => _.Category)
            .WithMany(_ => _.WorkSamples)
            .HasForeignKey(_ => _.CategoryId);
    }
}