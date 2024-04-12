namespace Persistence.Ef.Repositories.CustomerLogos;

public class EfCustomerLogoQuery : ICustomerLogoQuery
{
    private readonly DbSet<CustomerLogo> _customers;

    public EfCustomerLogoQuery(ApplicationDbContext context)
    {
        _customers = context.Set<CustomerLogo>();
    }

    public async Task<ICollection<GetCustomerLogosDto>> GetAll()
    {
        return await _customers
            .Select(customer => new GetCustomerLogosDto()
            {
                Id = customer.Id,
                Link = customer.Link,
                Logo = customer.Logo,
                Order = customer.Order,
                LogoAlt = customer.LogoAlt
            })
            .ToListAsync();
    }
}