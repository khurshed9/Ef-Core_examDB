using examdb.Infrastucture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examdb.EntitiesConfiguration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.Id).HasColumnName("id");
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("firstName");
        
        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("lastName");
        
        builder.Property(e=>e.Email).HasColumnName("email");
        
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(20).HasColumnName("phone");
        
        builder.Property(h => h.HireDate).IsRequired().HasColumnName("hireDate");
        
        builder.Property(p => p.Position).IsRequired().HasColumnName("position");

        builder.Property(s => s.Salary).IsRequired().HasColumnName("salary");
        builder.ToTable(s=>s.HasCheckConstraint("ValidSalary","salary > 0"));

        builder.Property(d => d.DepartmentName).IsRequired().HasColumnName("departmentName");

        builder.Property(m => m.ManagerId).HasColumnName("managerId");

        builder.Property(i => i.IsActive).IsRequired().HasDefaultValue(true).HasColumnName("isActive");

        builder.Property(a => a.Address).IsRequired().HasColumnName("address");

        builder.Property(c => c.City).IsRequired().HasColumnName("city");

        builder.Property(c => c.Country).IsRequired().HasColumnName("country");

        builder.Property(c => c.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP") .HasColumnName("createdAt");

        builder.Property(u => u.UpdatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("updatedAt");

    }
}