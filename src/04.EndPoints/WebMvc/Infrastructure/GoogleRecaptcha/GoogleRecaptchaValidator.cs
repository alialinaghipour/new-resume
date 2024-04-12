using Microsoft.Extensions.Options;

namespace WebMvc.Infrastructure.GoogleRecaptcha;

public class GoogleRecaptchaValidator : IGoogleRecaptchaValidator
{
    private readonly ICaptchaValidator _captchaValidator;

    public GoogleRecaptchaValidator(
        IOptions<GoogleRecaptchaConfig> config,
        ICaptchaValidator captchaValidator)
    {
        _captchaValidator = captchaValidator;
        _captchaValidator.UpdateSecretKey(config.Value.SecretKey);
    }

    public async Task<bool> IsCaptchaPassed(string token)
    {
        return await _captchaValidator.IsCaptchaPassedAsync(token);
    }
}