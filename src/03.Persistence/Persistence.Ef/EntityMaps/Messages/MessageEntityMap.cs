namespace Persistence.Ef.EntityMaps.Messages;

public class MessageEntityMap : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();

        builder.Property(_ => _.Name)
            .HasMaxLength(255);
        builder.Property(_ => _.Email)
            .HasMaxLength(500);
        builder.Property(_ => _.Text)
            .HasMaxLength(1000);
    }
}