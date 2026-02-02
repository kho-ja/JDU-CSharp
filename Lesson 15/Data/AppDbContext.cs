using Lesson_15.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson_15.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
}
