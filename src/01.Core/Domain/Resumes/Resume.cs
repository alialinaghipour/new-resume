namespace Domain.Resumes;

public abstract class Resume
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public int Order { get; set; } = 0;
    public required string StartDate { get; set; }
    public required string EndDate { get; set; }
    public required string Description { get; set; }
}