using Queries.SocialMedias.Dto;

namespace Queries.SocialMedias;

public interface ISocialMediaQuery : IScope
{
    Task<List<GetAllSocialMediaDto>> GetAll();
}