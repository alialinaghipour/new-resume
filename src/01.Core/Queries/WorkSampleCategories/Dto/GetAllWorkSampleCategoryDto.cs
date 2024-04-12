namespace Queries.WorkSampleCategories.Dto;

public class GetAllWorkSampleCategoryDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public int Order { get; set; } = 0;
}