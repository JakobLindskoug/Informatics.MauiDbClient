using Informatics.MauiDbClient.Contexts;
using Informatics.MauiDbClient.Models;
using Microsoft.EntityFrameworkCore;
namespace Informatics.MauiDbClient.Services;
public class DepartmentService : IDepartmentService
{
    private UniversityContext _context;
    public DepartmentService(UniversityContext context)
    {
        _context = context;
    }
    public async Task<Department> SaveDepartmentAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return department;
    }
    public async Task<Department> DeleteDepartmentAsync(string name)
    {
        var department = await _context.Departments.FindAsync(name);
        if (department == null)
        {
            return null;
        }
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return department;
    }
    public async Task<Department> GetDepartmentAsync(string name)
    {
        return await _context.Departments.FindAsync(name);
    }
    public async Task<IEnumerable<Department>> GetDepartmentsAsync()
    {
        return await _context.Departments.ToListAsync();
    }
    public async Task<Department> UpdateDepartmentAsync(Department department)
    {
        _context.Entry(department).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return department;
    }
}