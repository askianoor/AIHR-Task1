using Microsoft.EntityFrameworkCore;
using Task1.Domain.Enums;
using Task1.Domain.Interfaces.IRepositories;
using Task1.Domain.Models;
using Task1.Infrastructure.Context;

namespace Task1.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(Task1DbContext context) : base(context) { }

    public override async Task<List<Course>> GetAll()
    {
        return await _db.Courses.AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Course>> GetCoursesByCategoryId(long categoryId)
    {
        return await Search(b => b.CategoryId == categoryId);
    }

    public async Task<IEnumerable<Course>> GetCoursesByType(CourseType type)
    {
        return await _db.Courses.AsNoTracking()
            .Where(b => b.Type == type)
            .ToListAsync();
    }

    public async Task<IEnumerable<Course>> GetCoursesByLevel(CourseLevel level)
    {
        return await _db.Courses.AsNoTracking()
            .Where(b => b.Level == level)
            .ToListAsync();
    }
}