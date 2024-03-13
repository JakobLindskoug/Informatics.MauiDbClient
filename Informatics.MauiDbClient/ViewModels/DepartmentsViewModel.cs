using System.Collections.ObjectModel;
using System.Windows.Input;
using Informatics.MauiDbClient.Models;
using Informatics.MauiDbClient.Pages;
using Informatics.MauiDbClient.Services;
namespace Informatics.MauiDbClient;
public class DepartmentsViewModel
{
    private readonly IDepartmentService _departmentService;
    public ObservableCollection<Department> Departments { get; set; }
    public ICommand OpenAddDepartmentCommand { get; private set; }
    public ICommand OpenDepartmentDetailsCommand { get; private set; }
    public ICommand RefreshCommand { get; private set; }
    public DepartmentsViewModel(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
        Departments = new ObservableCollection<Department>();
        OpenAddDepartmentCommand = new Command(OpenAddDepartment);
        OpenDepartmentDetailsCommand = new Command<string>(OpenDepartmentDetails);
        RefreshCommand = new Command(async () => await LoadDepartmentsAsync());
    }
    private void OpenAddDepartment()
    {
        // We pass an empty string to indicate that we are adding a new department
        OpenDepartmentDetails(string.Empty);
    }
    private void OpenDepartmentDetails(string name)
    {
        var route = $"{nameof(DepartmentDetailsPage)}?departmentName={name}";
        Shell.Current.GoToAsync(route);
    }
    private async Task LoadDepartmentsAsync()
    {
        var departments = await _departmentService.GetDepartmentsAsync();
        Departments.Clear();
        foreach (var department in departments)
        {
            Departments.Add(department);
        }
    }
}
