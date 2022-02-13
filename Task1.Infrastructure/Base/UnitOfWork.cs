using Task1.Domain.Interfaces.Base;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Base;
public class UnitOfWork : IUnitOfWork
{
    private Task1DbContext Context { get; }

    public UnitOfWork(Task1DbContext context)
    {
        Context = context;
    }

    public void Commit()
    {
        Context.SaveChanges();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}