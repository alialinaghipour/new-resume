using Services.Messages.Contracts;

namespace Persistence.Ef.Repositories.Messages;

public class EfMessageRepository : IMessageRepository
{
    private readonly DbSet<Message> _messages;

    public EfMessageRepository(ApplicationDbContext context)
    {
        _messages = context.Set<Message>();
    }
    
    public void Add(Message message)
    {
        _messages.Add(message);
    }
}