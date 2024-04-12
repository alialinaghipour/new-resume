namespace Queries.Works.Dto;

public class GetWorksDto
{
    public required string Id { get; set; }
    public required string Icon { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int ColumnLg { get; set; }
    public required int Order { get; set; }
}