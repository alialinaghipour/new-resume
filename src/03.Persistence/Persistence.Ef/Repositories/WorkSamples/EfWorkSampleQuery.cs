using Queries.WorkSamples;
using Queries.WorkSamples.Dto;

namespace Persistence.Ef.Repositories.WorkSamples;

public class EfWorkSampleQuery : IWorkSampleQuery
{
    private readonly DbSet<WorkSample> _workSamples;

    public EfWorkSampleQuery(ApplicationDbContext context)
    {
        _workSamples = context.Set<WorkSample>();
    }
    
    public async Task<List<GetAllWorkSampleDto>> GetAll()
    {
        var  result = await _workSamples
            .OrderBy(p => p.Order)
            .Select(p => new GetAllWorkSampleDto()
            {
                Id = p.Id,
                Image = p.Image,
                ImageAlt = p.ImageAlt,
                Link = p.Link,
                Order = p.Order,
                CategoryId = p.CategoryId,
                Title = p.Title
            })
            .ToListAsync();
        
        return result;
    }
}