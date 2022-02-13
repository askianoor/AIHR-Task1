namespace Task1.Domain.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    void Commit();
}