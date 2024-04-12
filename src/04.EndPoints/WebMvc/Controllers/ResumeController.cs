namespace WebMvc.Controllers;

public class ResumeController : Controller
{
    private readonly IEducationQuery _educationQuery;
    private readonly IExperienceQuery _experienceQuery;
    private readonly ISkillQuery _skillQuery;

    public ResumeController(
        IEducationQuery educationQuery,
        IExperienceQuery experienceQuery,
        ISkillQuery skillQuery)
    {
        _educationQuery = educationQuery;
        _experienceQuery = experienceQuery;
        _skillQuery = skillQuery;
    }
    
    public async Task<IActionResult> Index()
    {
        var educations = await _educationQuery.GetAll();
        var experience = await _experienceQuery.GetAll();
        var skills = await _skillQuery.GetAll();

        var model = new ResumeViewModel()
        {
            Educations = educations
                .Select(_=> new GetEducationsViewModel()
                {
                    Id = _.Id,
                    Description = _.Description,
                    Order = _.Order,
                    Title = _.Title,
                    EndDate = _.EndDate,
                    StartDate = _.StartDate
                }).ToList(),
             Experiences = experience
                 .Select(_=> new GetExperiencesViewModel()
                 {
                     Id = _.Id,
                     Description = _.Description,
                     Order = _.Order,
                     Title = _.Title,
                     EndDate = _.EndDate,
                     StartDate = _.StartDate
                 }).ToList(), 
             Skills = skills
                 .Select(_=> new GetSkillsViewModel()
                 {
                     Id = _.Id,
                     Order = _.Order,
                     Title = _.Title,
                     Percent = _.Percent
                 }).ToList(),
        };
        return View(model);
    }
}