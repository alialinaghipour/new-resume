namespace Queries.SocialMedias.Dto;

public class GetAllSocialMediaDto
{
    public required string Id { get; set; }
    public required string Link { get; set; }
    public required string Icon { get; set; }
    public int Order { get; set; } = 0;
}