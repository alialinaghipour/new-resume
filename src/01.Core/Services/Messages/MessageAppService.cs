using Services.Messages.Contracts;
using Services.Messages.Contracts.Dto;

namespace Services.Messages;

public class MessageAppService : IMessageService
{
    private readonly IMessageRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public MessageAppService(
        IMessageRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Add(AddMessageByContactDto dto)
    {
        var message = new Message()
        {
            Id = Guid.NewGuid().ToString(),
            Email = dto.Email,
            Name = dto.Name,
            Text = dto.Text
        };

        _repository.Add(message);
        await _unitOfWork.Save();
    }
}