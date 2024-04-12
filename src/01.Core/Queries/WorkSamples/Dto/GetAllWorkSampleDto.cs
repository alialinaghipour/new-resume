namespace Queries.WorkSamples.Dto;

public class GetAllWorkSampleDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? Link { get; set; }
    public required string Image { get; set; }
    public required string ImageAlt { get; set; }
    public int Order { get; set; }
    public required string CategoryId { get; set; }
}