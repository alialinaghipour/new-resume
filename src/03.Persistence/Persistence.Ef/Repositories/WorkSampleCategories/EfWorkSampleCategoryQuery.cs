using Domain.WorkSampleCategories;
using Queries.WorkSampleCategories;
using Queries.WorkSampleCategories.Dto;

namespace Persistence.Ef.Repositories.WorkSampleCategories;

public class EfWorkSampleCategoryQuery : IWorkSampleCategoryQuery
{
    private readonly DbSet<WorkSampleCategory> _workSampleCategories;

    public EfWorkSampleCategoryQuery(ApplicationDbContext context)
    {
        _workSampleCategories = context.Set<WorkSampleCategory>();
    }
    
    public async Task<List<GetAllWorkSampleCategoryDto>> GetAll()
    {
        var result = await _workSampleCategories
            .OrderBy(pc => pc.Order)
            .Select(pc => new GetAllWorkSampleCategoryDto()
            {
                Id = pc.Id,
                Order = pc.Order,
                Title = pc.Title
            })
            .ToListAsync();

        return result;
    }
}