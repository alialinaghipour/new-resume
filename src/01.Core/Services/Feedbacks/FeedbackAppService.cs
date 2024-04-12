namespace Services.Feedbacks;

public class FeedbackAppService : IFeedbackService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly FeedbackRepository _repository;

    public FeedbackAppService(
        IUnitOfWork unitOfWork,
        FeedbackRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task Add(AddFeedbackDto dto)
    {
        var idIsExists = await _repository.IsExists(_ => _.Id == dto.Id);
        if (idIsExists)
        {
            throw new IdIsDuplicateException();
        }
        
        var feedback = new Feedback()
        {
            Id = dto.Id,
            Avatar = dto.Avatar,
            Description = dto.Description,
            Name = dto.Name,
            Order = dto.Order
        };

         _repository.Add(feedback);
         await _unitOfWork.Save();
    }

    public async Task Update(UpdateFeedbackDto dto)
    {
        var feedback = await _repository.Find(_ => _.Id == dto.Id);
        ThrowExceptionWhenFeedbackNotFound(feedback);
        
        feedback.Description = dto.Description;
        feedback.Avatar = dto.Avatar;
        feedback.Order = dto.Order;
        feedback.Name = dto.Name;
        
        _repository.Update(feedback);
        await _unitOfWork.Save();
    }
    
    public async Task Delete(string id)
    {
        var feedback = await _repository.Find(_ => _.Id == id);
        ThrowExceptionWhenFeedbackNotFound(feedback);

        _repository.Delete(feedback!);
        await _unitOfWork.Save();
    }
    
    private static void ThrowExceptionWhenFeedbackNotFound(Feedback? feedback)
    {
        if (feedback is null)
        {
            throw new NotFoundException();
        }
    }
}