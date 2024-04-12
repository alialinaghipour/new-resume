using Queries.Educations.Dto;

namespace Queries.Educations;

public interface IEducationQuery : IScope
{
    Task<ICollection<GetEducationsDto>> GetAll();
}