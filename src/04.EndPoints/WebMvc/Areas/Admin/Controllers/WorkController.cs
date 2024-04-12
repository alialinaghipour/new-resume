using Services.Exceptions;

namespace WebMvc.Areas.Admin.Controllers;

public class WorkController : AdminBaseController
{
    private readonly IWorkQuery _workQuery;
    private readonly IMapper _mapper;
    private readonly IWorkService _workService;

    public WorkController(
        IWorkQuery workQuery,
        IMapper mapper,
        IWorkService workService)
    {
        _workQuery = workQuery;
        _mapper = mapper;
        _workService = workService;
    }

    public async Task<IActionResult> Index()
    {
        var works = await _workQuery.GetAll();

        var model = _mapper.Map<List<GetWorksViewModel>>(works);

        return View(model);
    }

    #region Create

    public IActionResult LoadCreateModal(string id)
    {
        return PartialView("CreateModalPartial", new AddWorkViewModel());
    }

    public async Task<IActionResult> Create(AddWorkViewModel model)
    {
        try
        {
            var work = _mapper.Map<AddWorkDto>(model);
            await _workService.Add(work);

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

    #endregion

    #region Update

    public async Task<IActionResult> LoadUpdateModal(string id)
    {
        var work = await _workQuery.Find(_ => _.Id == id);
        var model = _mapper.Map<UpdateWorkViewModel>(work);
        return PartialView("_updateModalPartial", model);
    }

    public async Task<IActionResult> Update(UpdateWorkViewModel model)
    {
        try
        {
            var dto = _mapper.Map<UpdateWorkDto>(model);
            await _workService.Update(dto);

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

    #endregion


    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _workService.Delete(id);
            return new JsonResult(new { status = "Success" });
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