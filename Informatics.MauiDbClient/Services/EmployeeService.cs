using Informatics.MauiDbClient.Contexts;
using Informatics.MauiDbClient.Models;
using Microsoft.EntityFrameworkCore;
namespace Informatics.MauiDbClient.Services;
public class EmployeeService : IEmployeeService
{
    private UniversityContext _context;
    public EmployeeService(UniversityContext context)
    {
        _context = context;
    }
    public async Task<Employee> SaveEmployeeAsync(Employee employee)
    {
        // Set the DepartmentName property to the Department.Name value
        employee.DepartmentName = employee.Department.Name;
        // Set the Department property to null to avoid PK violation
        employee.Department = null;
        // if -1 then add new employee
        if (employee.Id == -1)
        {
            employee.Id = _context.Employees.Max(e => e.Id) + 1;
            _context.Employees.Add(employee);
        }
        else
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();
        return employee;
    }
    public async Task<Employee> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return null;
        }
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
    public async Task<Employee> GetEmployeeAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }
    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }
    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return employee;
    }
}
