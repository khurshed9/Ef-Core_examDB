using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examdb.Infrastucture.Entities;

[Table("employees")]
public class Employee
{
    
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
   
    public string Email { get; set; }


    public string Phone { get; set; }

    [Column("dateOfBirth", TypeName = "timestamp with time zone")] 
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    public DateTime HireDate { get; set; }
    
    public string Position { get; set; }

    public decimal Salary { get; set; }
    
    public string DepartmentName { get; set; }

    public Guid ManagerId { get; set; }
    
    public bool IsActive { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}