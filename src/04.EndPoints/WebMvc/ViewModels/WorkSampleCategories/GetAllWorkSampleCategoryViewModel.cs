namespace WebMvc.ViewModels.WorkSampleCategories;

public class GetAllWorkSampleCategoryViewModel
{
    public required string Id { get; set; }
    [Display(Name = "عنوان")]
    public required string Title { get; set; }
    [Display(Name = "الویت")]
    public int Order { get; set; }
}