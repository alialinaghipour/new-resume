namespace WebMvc.ViewModels.Skills;

public class GetSkillsViewModel
{
    public required string Id { get; set; }
    [Display(Name = "عنوان")]
    public required string Title { get; set; }
    [Display(Name = "درصد")]
    public required string Percent { get; set; }
    [Display(Name = "الویت")]
    public required int Order { get; set; }
}