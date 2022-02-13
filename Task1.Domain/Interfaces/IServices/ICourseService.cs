using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Domain.Models;

namespace Task1.Domain.Interfaces.IServices;

public interface ICourseService : IDisposable
{
    Task<IEnumerable<Course>> GetAll();
    Task<Course> GetById(long id);
    Task<Course> Add(Course course);
    Task<Course> Update(Course course);
    Task<bool> Remove(Course course);
    Task<IEnumerable<Course>> Search(string courseName);
    Task<IEnumerable<Course>> GetCoursesByCategoryId(long categoryId);
    Task<IEnumerable<Course>> GetCoursesByType(string searchedValue);
}