using Queries.WorkSamples.Dto;

namespace Queries.WorkSamples;

public interface IWorkSampleQuery : IScope
{
    Task<List<GetAllWorkSampleDto>> GetAll();
}