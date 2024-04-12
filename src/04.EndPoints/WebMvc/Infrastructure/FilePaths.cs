namespace WebMvc.Infrastructure;

public static class FilePaths
{
    public const string BaseImagePath = "/content/images/";
    public const string BaseImagePathServer = $"wwwroot{BaseImagePath}";
    public const string DefaultAvatar = $"{BaseImagePath}/default/default-avatar.png";
    public static readonly string FeedbackAvatar = $"{BaseImagePath}/customer-feedback-avatar/origin/";
    public static readonly string Avatar = $"{BaseImagePath}/avatar/";
    
    #region CustomerLogo 
    public static readonly string CustomerLogo = $"{BaseImagePath}/customer-logo/origin/";
    #endregion
    
    #region WorkSample
    public static readonly string WorkSample = $"{BaseImagePath}/work-sample/";
    #endregion
    
    
    #region Resume
    public static readonly string Resume = $"{BaseImagePath}/resume/";
    #endregion

}