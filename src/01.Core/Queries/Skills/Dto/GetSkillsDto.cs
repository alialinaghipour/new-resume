namespace Queries.Skills.Dto;

public class GetSkillsDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required int Order { get; set; } = 0;
    public required string Percent { get; set; }
}