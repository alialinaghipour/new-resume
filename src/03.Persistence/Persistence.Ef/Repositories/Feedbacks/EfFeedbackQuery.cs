namespace Persistence.Ef.Repositories.Feedbacks;

public class EfFeedbackQuery : IFeedbackQuery
{
    private readonly DbSet<Feedback> _customerFeedbacks;
    
    public EfFeedbackQuery(ApplicationDbContext context)
    {
        _customerFeedbacks = context.Set<Feedback>();
    }
    
    public async Task<ICollection<GetFeedbacksDto>> GetAll()
    {
        return await _customerFeedbacks
            .Select(feedback => new GetFeedbacksDto()
            {
                Id = feedback.Id,
                Name = feedback.Name,
                Avatar = feedback.Avatar,
                Description = feedback.Description,
                Order = feedback.Order
            })
            .OrderBy(feedback => feedback.Order)
            .ToListAsync();
    }
}