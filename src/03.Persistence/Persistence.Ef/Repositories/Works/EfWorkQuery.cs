using System.Linq.Expressions;

namespace Persistence.Ef.Repositories.Works;

public class EfWorkQuery : IWorkQuery
{
    private readonly DbSet<Work> _works;
    public EfWorkQuery(ApplicationDbContext context)
    {
        _works = context.Set<Work>();
    }
    
    public async Task<ICollection<GetWorksDto>> GetAll()
    {
        var works = await _works
            .Select(work => new GetWorksDto()
            {
                Id = work.Id,
                Description = work.Description,
                Icon = work.Icon,
                Order = work.Order,
                Title = work.Title,
                ColumnLg = work.ColumnLg
            })
            .ToListAsync();

        return works;
    }

    public async Task<Work?> Find(Expression<Func<Work, bool>> condition)
    {
        return await _works
            .Where(condition)
            .FirstOrDefaultAsync();
    }
}