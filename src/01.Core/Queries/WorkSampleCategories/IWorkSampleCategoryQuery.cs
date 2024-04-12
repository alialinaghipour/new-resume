namespace Queries.WorkSampleCategories;

public interface IWorkSampleCategoryQuery : IScope
{
    Task<List<GetAllWorkSampleCategoryDto>> GetAll();
}