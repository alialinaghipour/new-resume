namespace Services.Messages.Contracts;

public interface IMessageRepository : IScope
{
    void Add(Message message);
}