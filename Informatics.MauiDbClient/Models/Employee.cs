using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Informatics.MauiDbClient.Models;
[Table("Employee")]
public class Employee
{
    [Key]
    [Column("EmpId")]
    public int Id { get; set; }
    [Column("EmpName")]
    [MaxLength(100)]
    public string Name { get; set; }
    [Column("EmpSalary")]
    public int Salary { get; set; }
    [Column("DeptName")]
    [MaxLength(100)]
    [ForeignKey("Department")]
    public string DepartmentName { get; set; }
    // Navigation property for the related row in the Department table
    public virtual Department Department { get; set; }
}