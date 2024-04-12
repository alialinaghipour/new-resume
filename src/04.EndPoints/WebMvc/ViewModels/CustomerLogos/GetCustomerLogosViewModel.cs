namespace WebMvc.ViewModels.CustomerLogos;

public class GetCustomerLogosViewModel
{
    public required string Id { get; set; }
    [Display(Name = "لوگو")]
    public required string Logo { get; set; }
    [Display(Name = "توضیحات لوگو")]
    public required string LogoAlt { get; set; }
    [Display(Name = "لینک")]
    public required string Link { get; set; }
    [Display(Name = "الویت")]
    public required int Order { get; set; }
}