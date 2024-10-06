namespace examdb.Infrastucture.Queries;

public class GetEmployeesByStatistics
{
    public int EmployeeCount { get; set; }

    public decimal MinimumSalary { get; set; }

    public decimal AverageSalary { get; set; }

    public decimal MaximumSalary { get; set; }
}