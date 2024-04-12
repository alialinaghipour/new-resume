namespace WebMvc.ViewModels.WorkSamples;

public class GetAllWorkSampleViewModel
{
    public string Id { get; set; }
    [Display(Name = "عنوان")]
    public string Title { get; set; }
    [Display(Name = "تاریخ شروع")]
    public string? Link { get; set; }
    [Display(Name = "تصویر")]
    public string Image { get; set; }
    [Display(Name = "توضیح تصویر")]
    public string ImageAlt { get; set; }
    [Display(Name = "الویت")]
    public int Order { get; set; }
    public required string CategoryId { get; set; }
}