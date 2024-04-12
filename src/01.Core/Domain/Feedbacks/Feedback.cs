namespace Domain.Feedbacks;

public class Feedback
{
    public required string Id { get; set; }
    public required string Avatar { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Order { get; set; } = 0;
}