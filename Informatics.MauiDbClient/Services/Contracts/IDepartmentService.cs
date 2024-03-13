using Informatics.MauiDbClient.Models;
namespace Informatics.MauiDbClient;
public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task<Department> GetDepartmentAsync(string name);
    Task<Department> SaveDepartmentAsync(Department department);
    Task<Department> UpdateDepartmentAsync(Department department);
    Task<Department> DeleteDepartmentAsync(string name);
}

