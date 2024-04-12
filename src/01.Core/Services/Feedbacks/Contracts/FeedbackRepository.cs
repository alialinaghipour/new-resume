namespace Services.Feedbacks.Contracts;

public interface FeedbackRepository : IScope
{
    void Add(Feedback feedback);
    void Delete(Feedback feedback);
    void Update(Feedback feedback);
    Task<Feedback?> Find(Expression<Func<Feedback,bool>> condition);
    Task<bool> IsExists(Expression<Func<Feedback,bool>> condition);
}