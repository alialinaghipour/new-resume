namespace WebMvc.ViewModels.Feedbacks;

public class AddFeedbackViewModel
{
    public string Id { get; set; }
    [Display(Name = "آواتار")]
    public string Avatar { get; set; }
    [Display(Name = "نام")]
    public string Name { get; set; }
    [Display(Name = "توضیحات")]
    public string Description { get; set; }
    [Display(Name = "الویت")]
    public int Order { get; set; }
}