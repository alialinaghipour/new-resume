namespace Services.Feedbacks.Contracts;

public interface IFeedbackService : IScope
{
    Task Add(AddFeedbackDto dto);
    Task Update(UpdateFeedbackDto dto);
    Task Delete(string id);
}