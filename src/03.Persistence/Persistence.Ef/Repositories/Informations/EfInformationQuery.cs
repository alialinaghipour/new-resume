using Queries.Informations;
using Queries.Informations.Dto;

namespace Persistence.Ef.Repositories.Informations;

public class EfInformationQuery : IInformationQuery
{
    private readonly ApplicationDbContext _context;

    public EfInformationQuery(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetInformationDto?> Get()
    {
        return await _context.Set<Information>()
            .Select(_ => new GetInformationDto()
            {
                Id = _.Id,
                Name = _.Name,
                Address = _.Address,
                Avatar = _.Avatar,
                Email = _.Email,
                Job = _.Job,
                Phone = _.Phone,
                MapSrc = _.MapSrc,
                ResumeFile = _.ResumeFile,
                DateOfBirth = _.DateOfBirth,
            }).FirstOrDefaultAsync();
    }
}