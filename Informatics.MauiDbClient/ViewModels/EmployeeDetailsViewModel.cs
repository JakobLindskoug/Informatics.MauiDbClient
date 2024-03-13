using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Informatics.MauiDbClient.Models;
using Informatics.MauiDbClient.Services;
namespace Informatics.MauiDbClient;
public class EmployeeDetailsViewModel : INotifyPropertyChanged
{
    private Employee _employee;
    private IEmployeeService _employeeService;
    private IDepartmentService _departmentService;
    /*
    * Note: An Employee can work at 1 Department. This backing field
    * is used to populate the Department picker in the UI with all departments.
    */
    private ObservableCollection<Department> _departments;
    // OnPropertyChanged will be called when a property is set
    // (changed) which will update the UI
    public Employee Employee
    {
        get => _employee;
        set
        {
            _employee = value;
            OnPropertyChanged(nameof(Employee));
        }
    }
    public ObservableCollection<Department> Departments
    {
        get => _departments;
        set
        {
            _departments = value;
            OnPropertyChanged(nameof(Departments));
        }
    }
    public ICommand SaveEmployeeCommand { get; private set; }
    public ICommand DeleteEmployeeCommand { get; private set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    public EmployeeDetailsViewModel(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
        _departments = new ObservableCollection<Department>();
        SaveEmployeeCommand = new Command(SaveEmployee);
        DeleteEmployeeCommand = new Command(DeleteEmployee);
    }
    public async void LoadEmployee(int employeeId)
    {
        Employee = await _employeeService.GetEmployeeAsync(employeeId);
        if (Employee == null)
        {
            Employee = new Employee();
            Employee.Id = employeeId;
        }
    }
    private void SaveEmployee()
    {
        _employeeService.SaveEmployeeAsync(Employee);
        Shell.Current.GoToAsync("..");
    }
    private void DeleteEmployee()
    {
        _employeeService.DeleteEmployeeAsync(Employee.Id);
        Shell.Current.GoToAsync("..");
    }
    public async void LoadDepartments()
    {
        var departments = await _departmentService.GetDepartmentsAsync();
        Departments = new ObservableCollection<Department>(departments);
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}