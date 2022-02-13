using Microsoft.EntityFrameworkCore;
using Task1.Domain.Models;

namespace Task1.Infrastructure.Context;

public class Task1DbContext : DbContext
{
    public Task1DbContext(DbContextOptions options) : base(options) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tutor> Tutors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Task1DbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }
}