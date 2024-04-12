namespace WebMvc.Infrastructure.GoogleRecaptcha;

public interface IGoogleRecaptchaValidator 
{
    Task<bool> IsCaptchaPassed(string token);
}