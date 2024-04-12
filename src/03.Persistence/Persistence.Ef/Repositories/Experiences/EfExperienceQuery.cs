namespace Persistence.Ef.Repositories.Experiences;

public class EfExperienceQuery : IExperienceQuery
{
    private readonly DbSet<Experience> _experiences;
    public EfExperienceQuery(ApplicationDbContext context)
    {
        _experiences = context.Set<Experience>();
    }
    
    public async Task<ICollection<GetExperiencesDto>> GetAll()
    {
        return await _experiences
            .Select(education => new GetExperiencesDto()
            {
                Id = education.Id,
                Description = education.Description,
                Order = education.Order,
                Title = education.Title,
                EndDate = education.EndDate,
                StartDate = education.StartDate
            })
            .ToListAsync();
    }
}