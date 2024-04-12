using Framework.Contracts;
using WebMvc.Infrastructure.GoogleRecaptcha;

namespace WebMvc.ViewModels.Messages;

public class AddMessageByContactViewModel : IGoogleRecaptchaProperty
{
    [Display(Name = " نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(250, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
    [SanitizeHtml]
    public required string Name { get; set; }


    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(500, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
    [EmailAddress(ErrorMessage = "لطفا ایمیل وارد کنید")]
    [SanitizeHtml]
    public required string Email { get; set; }


    [Display(Name = "پیام")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
    [SanitizeHtml]
    public required string Text { get; set; }

    public string? Captcha { get; set; }
}