using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Informatics.MauiDbClient.Models;
[Table("Department")]
public class Department
{
    [Key]
    [Column("DeptName")]
    [MaxLength(100)]
    public string Name { get; set; }
    [Column("DeptBudget")]
    public int Budget { get; set; }
    // Navigation property for related rows in the Employee table
    public virtual ICollection<Employee> Employees { get; set; }
}

