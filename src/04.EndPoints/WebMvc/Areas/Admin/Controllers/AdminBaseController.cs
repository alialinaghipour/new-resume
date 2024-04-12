namespace WebMvc.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBaseController : Controller
{
    protected const string SuccessMessage = "SuccessMessage";
    protected const string WarningMessage = "WarningMessage";
    protected const string InfoMessage = "InfoMessage";
    protected const string ErrorMessage = "ErrorMessage";
}