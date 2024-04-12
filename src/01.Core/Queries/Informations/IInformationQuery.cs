using Queries.Informations.Dto;

namespace Queries.Informations;

public interface IInformationQuery : IScope
{
    Task<GetInformationDto?> Get();
}