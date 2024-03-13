using Informatics.MauiDbClient.Models;
using Microsoft.EntityFrameworkCore;
namespace Informatics.MauiDbClient.Contexts;
public class UniversityContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }
}