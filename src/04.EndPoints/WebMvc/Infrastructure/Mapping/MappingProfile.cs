using Domain.Feedbacks;
using Domain.Works;
using Queries.Feedbacks.Dto;
using Queries.Works.Dto;
using Services.Feedbacks.Contracts.Dto;

namespace WebMvc.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Works

        CreateMap<GetWorksDto, GetWorksViewModel>();
        CreateMap<AddWorkViewModel, Work>();
        CreateMap<UpdateWorkViewModel, Work>().ReverseMap();
        CreateMap<UpdateWorkViewModel, UpdateWorkDto>().ReverseMap();
        CreateMap<AddWorkViewModel, AddWorkDto>();
        CreateMap<Work, GetWorkByIdViewModel>();

        #endregion

        CreateMap<GetFeedbacksViewModel, GetFeedbacksDto>().ReverseMap();
        CreateMap<AddFeedbackViewModel, AddFeedbackDto>().ReverseMap();
    }
}