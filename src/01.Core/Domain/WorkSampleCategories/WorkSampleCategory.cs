using Domain.WorkSamples;

namespace Domain.WorkSampleCategories;

public class WorkSampleCategory
{
    public WorkSampleCategory()
    {
        WorkSamples = new HashSet<WorkSample>();
    }
    
    public required string Id { get; set; }
    public required string Title { get; set; }
    public int Order { get; set; } = 0;
    public ICollection<WorkSample> WorkSamples { get; set; }
}