using Queries.CustomerLogos.Dto;

namespace Queries.CustomerLogos;

public interface ICustomerLogoQuery : IScope
{
    Task<ICollection<GetCustomerLogosDto>> GetAll();
}