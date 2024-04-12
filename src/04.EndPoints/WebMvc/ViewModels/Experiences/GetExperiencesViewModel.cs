namespace WebMvc.ViewModels.Experiences;

public class GetExperiencesViewModel
{
    public required string Id { get; set; }
    [Display(Name = "عنوان")]
    public required string Title { get; set; }
    [Display(Name = "تاریخ شروع")]
    public required string StartDate { get; set; }
    [Display(Name = "تاریخ پایان")]
    public required string EndDate { get; set; }
    [Display(Name = "توضیحات")]
    public required string Description { get; set; }
    [Display(Name = "الویت")]
    public required int Order { get; set; }
}