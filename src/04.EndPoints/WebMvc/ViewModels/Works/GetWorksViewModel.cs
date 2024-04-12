namespace WebMvc.ViewModels.Works;

public class GetWorksViewModel
{
    public required string Id { get; set; }
    
    [Display(Name = "آیکون")]
    public required string Icon { get; set; }
    
    [Display(Name = "عنوان")]
    public required string Title { get; set; }

    [Display(Name = "توضیحات")]
    public required string Description { get; set; }

    [Display(Name = "عرض ستون آیتم")]
    public required int ColumnLg { get; set; }

    [Display(Name = "الویت")]
    public required int Order { get; set; }
}