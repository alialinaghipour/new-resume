using Queries.CustomerLogos;
using WebMvc.ViewModels.CustomerLogos;

namespace WebMvc.Controllers;
public class HomeController : Controller
{
    private readonly IWorkQuery _workQuery;
    private readonly IFeedbackQuery _feedbackQuery;
    private readonly ICustomerLogoQuery _customerLogoQuery;

    public HomeController(
        IWorkQuery workQuery,
        IFeedbackQuery feedbackQuery,
        ICustomerLogoQuery customerLogoQuery)
    {
        _workQuery = workQuery;
        _feedbackQuery = feedbackQuery;
        _customerLogoQuery = customerLogoQuery;
    }
    public async Task<IActionResult> Index()
    {
        var works = await _workQuery.GetAll();
        var feedbacks = await _feedbackQuery.GetAll();
        var customerLogos = await _customerLogoQuery.GetAll();
        var model = new HomeIndexViewModel()
        {
            Works = works.Select(_=> new GetWorksViewModel()
            {
                Id = _.Id,
                Description = _.Description,
                Icon = _.Icon,
                Title = _.Title,
                ColumnLg = _.ColumnLg,
                Order = _.Order
            }).ToList(),
            Feedbacks = feedbacks.Select(_=> new GetFeedbacksViewModel()
            {
                Id = _.Id,
                Avatar =  _.Avatar,
                Description = _.Description,
                Name = _.Name,
                Order = _.Order
            }).ToList(),
            Logos = customerLogos.Select(_=> new GetCustomerLogosViewModel()
            {
                Id = _.Id,
                Link = _.Link,
                Logo = _.Logo,
                Order = _.Order,
                LogoAlt = _.LogoAlt
            }).ToList()
        };
        
        return View(model);
    }
   
}