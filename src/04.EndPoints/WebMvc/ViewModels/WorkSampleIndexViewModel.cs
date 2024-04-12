namespace WebMvc.ViewModels;

public class WorkSampleIndexViewModel
{
    public List<GetAllWorkSampleViewModel> WorkSamples { get; set; } = new();
    public List<GetAllWorkSampleCategoryViewModel> WorkSampleCategories { get; set; } = new();
}