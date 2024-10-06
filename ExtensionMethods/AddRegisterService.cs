using examEfCore.Inrastucture.Services;

namespace examEfCore.ExtensionMethods;

public static class AddRegisterService
{
    public static void AddService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
    }
}