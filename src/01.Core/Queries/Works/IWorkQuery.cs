using System.Linq.Expressions;
using Domain.Works;

namespace Queries.Works;

public interface IWorkQuery : IScope
{
    Task<ICollection<GetWorksDto>> GetAll();
    Task<Work?> Find(Expression<Func<Work, bool>> condition);
}