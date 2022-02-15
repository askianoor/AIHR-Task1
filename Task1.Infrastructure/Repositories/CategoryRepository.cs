using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Models;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(Task1DbContext db) : base(db)
    {
    }
}

