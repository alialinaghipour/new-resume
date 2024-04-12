using Queries.SocialMedias;
using Queries.SocialMedias.Dto;

namespace Persistence.Ef.Repositories.SocialMedias;

public class EfSocialMediaQuery : ISocialMediaQuery
{
    private readonly ApplicationDbContext _context;

    public EfSocialMediaQuery(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetAllSocialMediaDto>> GetAll()
    {
        return await _context.Set<SocialMedia>()
            .Select(_ => new GetAllSocialMediaDto()
            {
                Id = _.Id,
                Icon = _.Icon,
                Link = _.Link,
                Order = _.Order
            })
            .ToListAsync();
    }
}