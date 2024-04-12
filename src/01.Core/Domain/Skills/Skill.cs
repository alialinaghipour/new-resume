namespace Domain.Skills;

public class Skill
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required int Order { get; set; } = 0;
    public required string Percent { get; set; }
}