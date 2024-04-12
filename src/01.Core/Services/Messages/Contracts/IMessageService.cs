using Services.Messages.Contracts.Dto;

namespace Services.Messages.Contracts;

public interface IMessageService : IScope
{
    Task Add(AddMessageByContactDto dto);
}