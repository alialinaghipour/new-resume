namespace WebMvc.ViewModels.Feedbacks;

public class GetFeedbacksViewModel
{
    public required string Id { get; set; }
    [Display(Name = "آواتار")]
    public required string Avatar { get; set; }
    [Display(Name = "نام")]
    public required string Name { get; set; }
    [Display(Name = "توضیحات")]
    public required string Description { get; set; }
    [Display(Name = "الویت")]
    public required int Order { get; set; }
}