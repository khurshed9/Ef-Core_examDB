using Dapper;
using examdb.DataContext;
using examdb.Infrastucture.Entities;
using examdb.Infrastucture.Queries;
using Npgsql;

namespace examEfCore.Inrastucture.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDBContext context;

    private readonly string connectionString;
    
    public EmployeeService(ApplicationDBContext _context,IConfiguration _configuration)
    {
        context = _context;
        connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    #region GetEmployeesAsync

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.GetEmployees);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }


    #endregion

    #region GetEmployeeByIdAsync

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Employee>(SqlCommands.GetEmployeeById, new { Id = @id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion

    #region CreateEmployeeAsync

    public async Task<bool> CreateEmployeeAsync(Employee? employee)
    {
        try
        {
            if (employee == null) return false;
            await context.Employees.AddAsync(employee);
            int res = await context.SaveChangesAsync();
            return res!= 0;

        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }


    #endregion

    #region UpdateEmployeeAsync

    public async Task<bool> UpdateEmployeeAsync(Employee? employee)
    {
        try
        {
            Employee? existingEmployee = await context.Employees.FindAsync(employee?.Id);
            if (employee == null) return false;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.HireDate = employee.HireDate;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DepartmentName = employee.DepartmentName;
            existingEmployee.ManagerId = employee.ManagerId;
            existingEmployee.IsActive = employee.IsActive;
            existingEmployee.Address = employee.Address;
            existingEmployee.City = employee.City;
            existingEmployee.Country = employee.Country;
            existingEmployee.CreatedAt = employee.CreatedAt;
            existingEmployee.UpdatedAt = employee.UpdatedAt;
            int res = await context.SaveChangesAsync();
            return res!= 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }


    #endregion

    #region DeleteEmployeeAsync

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        try
        {
            Employee? employee = await context.Employees.FindAsync(id);
            if (employee == null) return false;
            context.Employees.Remove(employee);
            int res = await context.SaveChangesAsync();
            return res!= 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }


    #endregion

    public async Task<IEnumerable<Employee>> GetEmployeesByActiveAsync(bool isactive)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.GetActiveEmployees, new { isActive = @isactive });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(string departmentname)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.GetEmployeesByDepartmentName, new { departmentName = @departmentname });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<GetEmployeesByStatistics>> GetEmployeesStatisticsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetEmployeesByStatistics>(SqlCommands.GetEmployeesStatistics);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Employee>> GetEmployeesInPeriodBirthAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Employee>(SqlCommands.GetEmployeesInPeriodBirth, new { startDate, endDate });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommands
{
    public const string GetEmployees = "Select * from employees";
    
    public const string GetEmployeeById = "Select * from employees where id = @id";

    public const string GetActiveEmployees = "SELECT * FROM employees WHERE \"isActive\" = @isactive";

    public const string GetEmployeesByDepartmentName =
        "SELECT * from employees where \"departmentName\" = @departmentname";

    public const string GetEmployeesStatistics = @"Select  COUNT(*) as EmployeeCount,
                                                   MIN(Salary) as MinimumSalary,
                                                   AVG(Salary) as AverageSalary,
                                                   MAX(Salary) as MaximumSalary from employees;";

    public const string GetEmployeesInPeriodBirth = @"select * from employees
                                                      where ""dateOfBirth"" between @startDate and @endDate";
}