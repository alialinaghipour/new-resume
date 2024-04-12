namespace WebMvc.ViewModels;

public class ResumeViewModel
{
    public List<GetEducationsViewModel> Educations { get; set; } = new();
    public List<GetExperiencesViewModel> Experiences { get; set; } = new();
    public List<GetSkillsViewModel> Skills { get; set; } = new();
}