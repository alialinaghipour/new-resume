using Queries.Informations;
using WebMvc.ViewModels.Informations;

namespace WebMvc.ViewComponents;

public class SideBarViewComponent : ViewComponent
{
    private readonly ISocialMediaQuery _socialMediaQuery;
    private readonly IInformationQuery _informationQuery;

    public SideBarViewComponent(
        ISocialMediaQuery socialMediaQuery,
        IInformationQuery informationQuery)
    {
        _socialMediaQuery = socialMediaQuery;
        _informationQuery = informationQuery;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var socialMedia = await _socialMediaQuery.GetAll();
        var information = await _informationQuery.Get();

        var model = new SideBarViewModel()
        {
            SocialMedias = socialMedia.Select(_ => new GetAllSocialMediaViewModel()
                {
                    Icon = _.Icon,
                    Id = _.Id,
                    Link = _.Link,
                    Order = _.Order
                })
                .ToList(),
            Information = information is null 
            ? new GetInformationViewModel()
            : new GetInformationViewModel()
            {
                Id = information.Id,
                Address = information.Address,
                Avatar =  information.Avatar,
                Email = information.Email,
                Job = information.Job,
                Name = information.Name,
                Phone = information.Phone,
                MapSrc = information.MapSrc,
                ResumeFile = information.ResumeFile,
                DateOfBirth = information.DateOfBirth
            }
        };

        return View("SideBar", model);
    }
}