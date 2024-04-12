using Domain.WorkSampleCategories;

namespace Persistence.Ef.EntityMaps.WorkSampleCategories;

public class WorkSampleCategoryEntityMap : IEntityTypeConfiguration<WorkSampleCategory>
{
    public void Configure(EntityTypeBuilder<WorkSampleCategory> builder)
    {
        builder.ToTable("WorkSampleCategories");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
    }
}