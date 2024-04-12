namespace Queries.Informations.Dto;

public class GetInformationDto
{
    public required string Id { get; set; }
    public string? Avatar { get; set; }
    public required string Name { get; set; }
    public required string Job { get; set; }
    public required string DateOfBirth { get; set; }
    public required string Address { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string ResumeFile { get; set; }
    public required string MapSrc { get; set; }
}