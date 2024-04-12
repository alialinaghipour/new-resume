using WebMvc.ViewModels.CustomerLogos;

namespace WebMvc.ViewModels;

public class HomeIndexViewModel
{
    public List<GetWorksViewModel> Works { get; set; } = new();
    public List<GetFeedbacksViewModel> Feedbacks { get; set; } = new();
    public List<GetCustomerLogosViewModel> Logos { get; set; } = new();
}