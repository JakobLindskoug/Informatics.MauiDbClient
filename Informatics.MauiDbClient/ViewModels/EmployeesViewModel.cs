using System.Windows.Input;
using Informatics.MauiDbClient.Models;
using Informatics.MauiDbClient.Services;
using Informatics.MauiDbClient.Pages;
using System.Collections.ObjectModel;
namespace Informatics.MauiDbClient;
public class EmployeesViewModel
{
    private readonly IEmployeeService _employeeService;
    public ObservableCollection<Employee> Employees { get; private set; }
    public ICommand RefreshCommand { get; private set; }
    public ICommand OpenEmployeeDetailsCommand { get; private set; }
    public ICommand OpenAddEmployeeCommand { get; private set; }
    public EmployeesViewModel(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
        Employees = new ObservableCollection<Employee>();
        RefreshCommand = new Command(async () => await LoadEmployeesAsync());
        OpenEmployeeDetailsCommand = new Command<int>(OpenEmployeeDetails);
        OpenAddEmployeeCommand = new Command(OpenAddEmployee);
    }
    private void OpenAddEmployee()
    {
        // We pass -1 to indicate that we are adding a new employee
        OpenEmployeeDetails(-1);
    }
    private void OpenEmployeeDetails(int id)
    {
        var route = $"{nameof(EmployeeDetailsPage)}?employeeId={id}";
        Shell.Current.GoToAsync(route);
    }
    private async Task LoadEmployeesAsync()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        Employees.Clear();
        foreach (var employee in employees)
        {
            Employees.Add(employee);
        }
    }
}