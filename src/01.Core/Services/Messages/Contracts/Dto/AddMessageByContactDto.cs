namespace Services.Messages.Contracts.Dto;

public class AddMessageByContactDto
{
    [Required]
    [MaxLength(255)]
    [SanitizeHtml]
    public required string Name { get; set; }
    [Required]
    [EmailAddress]
    [MaxLength(500)]
    [SanitizeHtml]
    public required string Email { get; set; }
    [Required]
    [EmailAddress]
    [MaxLength(1000)]
    [SanitizeHtml]
    public required string Text { get; set; }
}