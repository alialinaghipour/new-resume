namespace Services.Works.Contracts.Dto;

public class UpdateWorkDto
{
    public required string Id { get; set; }
    public required string Icon { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required int ColumnLg { get; set; } = 6;
    public required int Order { get; set; } = 0;
}