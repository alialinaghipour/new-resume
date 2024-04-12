namespace Framework.Contracts.StringTools;

public static class StringTools
{
    public static bool IsBlank(this string value)
    {
        return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }

    public static bool IsDuplicate(this string firstValue, string secondValue)
    {
        return firstValue.Replace(" ", "") == secondValue.Replace(" ", "");
    }
}