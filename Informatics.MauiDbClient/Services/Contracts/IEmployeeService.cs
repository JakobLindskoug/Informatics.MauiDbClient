using Informatics.MauiDbClient.Models;
namespace Informatics.MauiDbClient.Services;
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task<Employee> GetEmployeeAsync(int id);
    Task<Employee> SaveEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task<Employee> DeleteEmployeeAsync(int id);
}

