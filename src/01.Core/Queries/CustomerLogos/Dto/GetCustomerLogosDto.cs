namespace Queries.CustomerLogos.Dto;

public class GetCustomerLogosDto
{
    public required string Id { get; set; }
    public required string Logo { get; set; }
    public required string LogoAlt { get; set; }
    public required string Link { get; set; }
    public required int Order { get; set; } = 0;
}