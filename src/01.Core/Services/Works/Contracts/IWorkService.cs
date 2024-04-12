namespace Services.Works.Contracts;

public interface IWorkService : IScope
{
    Task Add(AddWorkDto dto);
    Task Update(UpdateWorkDto dto);
    Task Delete(string id);
}