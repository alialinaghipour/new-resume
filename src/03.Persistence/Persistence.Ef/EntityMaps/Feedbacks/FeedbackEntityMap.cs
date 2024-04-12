namespace Persistence.Ef.EntityMaps.Feedbacks;

public class FeedbackEntityMap : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.ToTable("Feedbacks");

        builder.HasKey(feedback => feedback.Id);
        
        builder.Property(feedback => feedback.Name)
            .IsRequired();
        builder.Property(feedback => feedback.Description)
            .IsRequired();
        builder.Property(feedback => feedback.Avatar)
            .IsRequired();
        builder.Property(feedback => feedback.Order)
            .IsRequired();
    }
}