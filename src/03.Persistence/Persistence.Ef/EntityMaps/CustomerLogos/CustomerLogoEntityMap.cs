namespace Persistence.Ef.EntityMaps.CustomerLogos;

public class CustomerLogoEntityMap : IEntityTypeConfiguration<CustomerLogo>
{
    public void Configure(EntityTypeBuilder<CustomerLogo> builder)
    {
        builder.ToTable("CustomerLogos");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Link);
        builder.Property(customer => customer.Order);
        builder.Property(customer => customer.Logo);
        builder.Property(customer => customer.LogoAlt);
    }
}