using WebMvc.ViewModels.Informations;

namespace WebMvc.ViewModels;

public class SideBarViewModel
{
    public List<GetAllSocialMediaViewModel> SocialMedias { get; set; } = new();
    public GetInformationViewModel Information { get; set; }
}