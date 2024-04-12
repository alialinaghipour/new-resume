using System.ComponentModel.DataAnnotations;

namespace Infrastructure.CustomDataAnnotations.Persians;

[AttributeUsage(
    AttributeTargets.Property |
    AttributeTargets.Field |
    AttributeTargets.Parameter,
    AllowMultiple = false)]
public class RequiredPersian : RequiredAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return $"وارد کردن '{name}'،الزامی است";
    }
}