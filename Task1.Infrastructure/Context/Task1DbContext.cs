using Microsoft.EntityFrameworkCore;
using Task1.Domain.Models;

namespace Task1.Infrastructure.Context;

public class Task1DbContext : DbContext
{
    public Task1DbContext(DbContextOptions options) : base(options) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRequest> UserRequests { get; set; }
    public DbSet<UserRequestCourse> UserRequestCourses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Task1DbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        ConfigureCourses(modelBuilder);
        ConfigureUser(modelBuilder);
        ConfigureUserRequests(modelBuilder);
        ConfigureUserRequestCourses(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }


    #region Model Configuration

    private static void ConfigureCourses(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasOne(b => b.Category)
            .WithMany(b => b.Courses)
            .HasForeignKey(b => b.CategoryId);

        modelBuilder.Entity<Course>()
            .HasOne(b => b.Tutor)
            .WithMany(b => b.Courses)
            .HasForeignKey(b => b.TutorId);
    }

    private static void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(b => b.Username).IsUnique();
    }


    private static void ConfigureUserRequests(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRequest>()
            .HasOne(b => b.User)
            .WithMany(b => b.UserRequests)
            .HasForeignKey(b => b.UserId);
    }

    private static void ConfigureUserRequestCourses(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRequestCourse>()
            .HasOne(b => b.UserRequest)
            .WithMany(b => b.UserRequestCourses)
            .HasForeignKey(b => b.UserRequestId);

        modelBuilder.Entity<UserRequestCourse>()
            .HasOne(b => b.Course)
            .WithMany(b => b.UserRequestCourses)
            .HasForeignKey(b => b.CourseId);
    }

    #endregion
}