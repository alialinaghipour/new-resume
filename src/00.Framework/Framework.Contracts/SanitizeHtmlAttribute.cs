using System.ComponentModel.DataAnnotations;
using Ganss.Xss;

namespace Framework.Contracts;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class SanitizeHtmlAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success;

        var text = value.ToString();
        var htmlSanitizer = new HtmlSanitizer();
        htmlSanitizer.KeepChildNodes = true;
        htmlSanitizer.AllowDataAttributes = true;

        var sanitizedText = htmlSanitizer.Sanitize(text);

        if (text != sanitizedText)
            return new ValidationResult("The input contains potentially dangerous content.");

        return ValidationResult.Success;
    }
}