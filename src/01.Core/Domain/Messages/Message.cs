namespace Domain.Messages;

public class Message
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Text { get; set; }
}