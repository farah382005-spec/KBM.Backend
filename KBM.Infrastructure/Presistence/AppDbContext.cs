using KBM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace KBM.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Function> Functions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<DepartmentFunction> DepartmentFunctions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}
