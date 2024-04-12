using System.Linq.Expressions;

namespace Persistence.Ef.Repositories.Works;

public class EfWorkRepository : IWorkRepository
{
    private readonly ApplicationDbContext _context;

    public EfWorkRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> IsExist(Expression<Func<Work, bool>> condition)
    {
        return await _context.Set<Work>()
            .AnyAsync(condition);
    }

    public void Add(Work work)
    {
        _context.Set<Work>().Add(work);
    }

    public void Delete(string id)
    {
        _context.Set<Work>()
            .Where(_ => _.Id == id)
            .ExecuteDelete();
    }

    public void Update(Work work)
    {
        _context.Set<Work>()
            .Update(work);
    }
}