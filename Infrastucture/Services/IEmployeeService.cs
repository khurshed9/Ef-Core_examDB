
using examdb.Infrastucture.Entities;
using examdb.Infrastucture.Queries;

namespace examEfCore.Inrastucture.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(Guid id);

    Task<bool> CreateEmployeeAsync(Employee? employee);
    
    Task<bool> UpdateEmployeeAsync(Employee? employee);
    
    Task<bool> DeleteEmployeeAsync(Guid id);
    
    Task<IEnumerable<Employee>> GetEmployeesByActiveAsync(bool _isActive);

    Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(string departmentName);

    Task<IEnumerable<GetEmployeesByStatistics>> GetEmployeesStatisticsAsync();

    Task<IEnumerable<Employee>> GetEmployeesInPeriodBirthAsync(DateTime startDate, DateTime endDate);
}