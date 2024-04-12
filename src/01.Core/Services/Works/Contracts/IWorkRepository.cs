namespace Services.Works.Contracts;

public interface IWorkRepository : IScope
{
    Task<bool> IsExist(Expression<Func<Work, bool>> condition);
    void Add(Work work);
    void Delete(string id);
    void Update(Work work);
}