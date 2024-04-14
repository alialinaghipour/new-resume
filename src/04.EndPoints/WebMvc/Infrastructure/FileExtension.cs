namespace WebMvc.Infrastructure;

public static class FileExtension
{
    public static bool IsValidImageExtension(this string value)
    {
        return Path.GetExtension(value) == ".png" ||
               Path.GetExtension(value) == ".jpeg" ||
               Path.GetExtension(value) == ".jpg";
    }
}