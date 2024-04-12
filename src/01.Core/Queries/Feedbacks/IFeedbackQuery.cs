using Queries.Feedbacks.Dto;

namespace Queries.Feedbacks;

public interface IFeedbackQuery : IScope
{
    Task<ICollection<GetFeedbacksDto>> GetAll();
}