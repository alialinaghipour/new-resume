using Domain.WorkSampleCategories;

namespace Domain.WorkSamples;

public class WorkSample
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? Link { get; set; }
    public required string Image { get; set; }
    public required string ImageAlt { get; set; }
    public int Order { get; set; } = 0;
    public required string CategoryId { get; set; }
    public WorkSampleCategory Category { get; set; }
}