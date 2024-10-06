using examdb.Infrastucture.Entities;
using Microsoft.EntityFrameworkCore;

namespace examdb.DataContext;

public class ApplicationDBContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}