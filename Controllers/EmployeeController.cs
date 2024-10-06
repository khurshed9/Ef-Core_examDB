using examdb.Infrastucture.Entities;
using examEfCore.Inrastucture.Services;
using Microsoft.AspNetCore.Mvc;

namespace examEfCoreDb.Controllers;

[Route("/api/employees")]
[ApiController]

public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> GetEmployees()
    {
        return Results.Ok(await employeeService.GetEmployeesAsync());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> GetEmployeeById(Guid id)
    {
        if (id == null) return Results.BadRequest();
        return Results.Ok(await employeeService.GetEmployeeByIdAsync(id));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> CreateEmployee( [FromBody]Employee employee)
    {
        if (employee == null) return Results.BadRequest("Employee object is null.");
        var res = await employeeService.CreateEmployeeAsync(employee);
        return res? Results.Ok("Employee created successfully.") : Results.BadRequest("Failed to create employee.");
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> UpdateEmployee(Employee employee)
    {
        if (employee == null) return Results.NotFound();
        return Results.Ok(await employeeService.UpdateEmployeeAsync(employee));
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> DeleteEmployee(Guid id)
    {
        if (id == null) return Results.BadRequest();
        return Results.Ok(await employeeService.DeleteEmployeeAsync(id));
    }

    [HttpGet("/api/employees/isActive={isactive}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> GetEmployeesByActive([FromQuery]bool isactive)
    {
        return Results.Ok(await employeeService.GetEmployeesByActiveAsync(isactive));
    }

    [HttpGet("/api/employees/departmentName={departmentname}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> GetEmployeesByDepartmentName(string departmentname)
    {
        return Results.Ok(await employeeService.GetEmployeesByDepartmentNameAsync(departmentname));
    }
    
    [HttpGet("/api/employees/salary-statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> GetEmployeesStatistics()
    {
        return Results.Ok(await employeeService.GetEmployeesStatisticsAsync());
    }
    
    [HttpGet("/api/employees/birthdays")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IResult> GetEmployeesInPeriodBirth([FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
    {
        return Results.Ok(await employeeService.GetEmployeesInPeriodBirthAsync(startDate, endDate));
    }
}