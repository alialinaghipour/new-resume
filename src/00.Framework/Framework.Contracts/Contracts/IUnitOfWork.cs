namespace Framework.Contracts.Contracts;

public interface IUnitOfWork : IScope
{
    Task Save();
}