using Queries.Informations;
using Services.Messages;
using Services.Messages.Contracts;
using Services.Messages.Contracts.Dto;
using WebMvc.Infrastructure.GoogleRecaptcha;

namespace WebMvc.Controllers;

public class ContactUsController : Controller
{
    private readonly IMessageService _messageService;
    private readonly IInformationQuery _informationQuery;
    private readonly IGoogleRecaptchaValidator _googleRecaptchaValidator;

    public ContactUsController(
        IMessageService messageService,
        IInformationQuery informationQuery,
        IGoogleRecaptchaValidator googleRecaptchaValidator)
    {
        _messageService = messageService;
        _informationQuery = informationQuery;
        _googleRecaptchaValidator = googleRecaptchaValidator;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewData["Information"] = await _informationQuery.Get();
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(AddMessageByContactViewModel message)
    {
        ViewData["Information"] = await _informationQuery.Get();

        if (!await _googleRecaptchaValidator.IsCaptchaPassed(message.Captcha!))
        {
            ViewData["FormSubmitResult"] = false;
            return View(message);
        }

        if (!ModelState.IsValid)
        {
            return View(message);
        }

        await _messageService.Add(new AddMessageByContactDto()
        {
            Text = message.Text,
            Email = message.Email,
            Name = message.Name
        });


        ViewData["FormSubmitResult"] = true;

        return View();
    }
}