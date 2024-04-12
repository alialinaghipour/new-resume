using Queries.WorkSampleCategories;
using Queries.WorkSamples;

namespace WebMvc.Controllers;

public class WorkSamplesController  : Controller
{
    private readonly IWorkSampleQuery _workSampleQuery;
    private readonly IWorkSampleCategoryQuery _workSampleCategoryQuery;

    public WorkSamplesController(
        IWorkSampleQuery workSampleQuery,
        IWorkSampleCategoryQuery workSampleCategoryQuery)
    {
        _workSampleQuery = workSampleQuery;
        _workSampleCategoryQuery = workSampleCategoryQuery;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var workSamples = await _workSampleQuery.GetAll();
        var categories = await _workSampleCategoryQuery.GetAll();
        var index = new WorkSampleIndexViewModel()
        {
            WorkSamples = workSamples.Select(_ => new GetAllWorkSampleViewModel()
            {
                Id = _.Id,
                Order = _.Order,
                Title = _.Title,
                ImageAlt = _.ImageAlt,
                Link = _.Link,
                Image = _.Image,
                CategoryId = _.CategoryId
            }).ToList(),
            WorkSampleCategories = categories.Select(_ => new GetAllWorkSampleCategoryViewModel()
            {
                Id = _.Id,
                Order = _.Order,
                Title = _.Title
            }).ToList()
        };
        return View(index);
    }
}