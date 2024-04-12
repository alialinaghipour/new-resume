using Services.Exceptions;
using Services.Feedbacks.Contracts;
using Services.Feedbacks.Contracts.Dto;

namespace WebMvc.Areas.Admin.Controllers;

public class FeedbackController : AdminBaseController
{
    private readonly IFeedbackQuery _feedbackQuery;
    private readonly IFeedbackService _feedbackService;
    private readonly IMapper _mapper;

    public FeedbackController(
        IFeedbackQuery feedbackQuery,
        IFeedbackService feedbackService,
        IMapper mapper)
    {
        _feedbackQuery = feedbackQuery;
        _feedbackService = feedbackService;
        _mapper = mapper;
    }
    
    public async Task<IActionResult> Index()
    {
        var works = await _feedbackQuery.GetAll();

        var model = _mapper.Map<List<GetFeedbacksViewModel>>(works);

        return View(model);
    }
    
    public IActionResult LoadCreateFeedbackModal()
    {
        return PartialView("_CreateFeedbackModal", new AddFeedbackViewModel());
    }
    
    public async Task<IActionResult> Create(AddWorkViewModel model)
    {
        try
        {
            var feedback = _mapper.Map<AddFeedbackDto>(model);
            await _feedbackService.Add(feedback);

            return new JsonResult(new { status = "Success" });
        }
        catch (IdIsDuplicateException)
        {
            return new JsonResult(new
            {
                status = "Error",
                errorMessage = "ایدی تکراری است"
            });
        }
        catch
        {
            return new JsonResult(new
            {
                status = "Error",
                errorMessage = "خطایی رخ داده است"
            });
        }
    }
}