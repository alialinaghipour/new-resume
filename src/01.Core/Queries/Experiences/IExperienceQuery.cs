using Queries.Experiences.Dto;

namespace Queries.Experiences;

public interface IExperienceQuery : IScope
{
    Task<ICollection<GetExperiencesDto>> GetAll();
}