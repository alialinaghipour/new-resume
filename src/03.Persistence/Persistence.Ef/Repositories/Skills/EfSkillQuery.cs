namespace Persistence.Ef.Repositories.Skills;

public class EfSkillQuery : ISkillQuery
{
    private readonly DbSet<Skill> _skills;

    public EfSkillQuery(ApplicationDbContext context)
    {
        _skills = context.Set<Skill>();
    }
    
    public async Task<ICollection<GetSkillsDto>> GetAll()
    {
        return await _skills
            .Select(skill => new GetSkillsDto()
            {
                Id = skill.Id,
                Order = skill.Order,
                Percent = skill.Percent,
                Title = skill.Title
            })
            .ToListAsync();
    }
}