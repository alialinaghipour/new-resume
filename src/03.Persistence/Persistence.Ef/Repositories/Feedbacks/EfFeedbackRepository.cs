using System.Linq.Expressions;
using Services.Feedbacks.Contracts;

namespace Persistence.Ef.Repositories.Feedbacks;

public class EfFeedbackRepository : FeedbackRepository
{
    private readonly DbSet<Feedback> _feedbacks;
    
    public EfFeedbackRepository(ApplicationDbContext context)
    {
        _feedbacks = context.Set<Feedback>();
    }
    public void Add(Feedback feedback)
    {
        _feedbacks.Add(feedback);
    }

    public void Delete(Feedback feedback)
    {
        _feedbacks.Remove(feedback);
    }

    public void Update(Feedback feedback)
    {
        _feedbacks.Update(feedback);
    }

    public async Task<Feedback?> Find(Expression<Func<Feedback, bool>> condition)
    {
        return await _feedbacks
            .Where(condition)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsExists(Expression<Func<Feedback, bool>> condition)
    {
        return await _feedbacks
            .AnyAsync(condition);
    }
}