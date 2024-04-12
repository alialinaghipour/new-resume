namespace Queries.Skills;

public interface ISkillQuery : IScope
{
    Task<ICollection<GetSkillsDto>> GetAll();
}