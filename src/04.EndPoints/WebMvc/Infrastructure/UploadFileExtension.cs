namespace WebMvc.Infrastructure;

public static class UploadFileExtension
{
    public static async Task AddImageAjaxToServer(
        this IFormFile file,
        string fileName,
        string path)
    {
        var a =  Path.Combine(Directory.GetCurrentDirectory(), $"/content/images/customer-feedback-avatar/origin/");
        if (Directory.Exists(path) is false)
        {
            Directory.CreateDirectory(path);
        }

        var originalPath = path + fileName;

        await using var stream = new FileStream(originalPath,FileMode.Create);
        if (Directory.Exists(originalPath) is false)
        {
            await file.CopyToAsync(stream);
        }
    }
}