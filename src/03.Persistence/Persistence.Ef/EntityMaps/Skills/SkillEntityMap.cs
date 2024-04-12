using Domain.Resumes;

namespace Persistence.Ef.EntityMaps.Skills;

public class SkillEntityMap : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills");
        
        builder.HasKey(skill => skill.Id);

        builder.Property(skill => skill.Title).IsRequired();
        builder.Property(skill => skill.Order).IsRequired();
        
        builder.Property(skill => skill.Percent)
            .IsRequired(false);
    }
}