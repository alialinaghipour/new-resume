namespace WebMvc.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    public IActionResult Index()
    {
        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
        return View();
    }
}