namespace Persistence.Ef.Repositories.Educations;

public class EfEducationQuery : IEducationQuery
{
    private readonly DbSet<Education> _educations;
    public EfEducationQuery(ApplicationDbContext context)
    {
        _educations = context.Set<Education>();
    }
    
    public async Task<ICollection<GetEducationsDto>> GetAll()
    {
        return await _educations
            .Select(education => new GetEducationsDto()
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