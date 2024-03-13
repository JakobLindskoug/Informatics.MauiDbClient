using System.ComponentModel;
using System.Windows.Input;
using Informatics.MauiDbClient.Models;
using Informatics.MauiDbClient.Pages;
using Informatics.MauiDbClient.Services;
namespace Informatics.MauiDbClient;
public class DepartmentDetailsViewModel : INotifyPropertyChanged
{
    private readonly IDepartmentService _departmentService;
    private Department _department;
    public Department Department
    {
        get => _department;
        set
        {
            _department = value;
            OnPropertyChanged(nameof(Department));
        }
    }
    public ICommand SaveDepartmentCommand { get; private set; }
    public ICommand DeleteDepartmentCommand { get; private set; }
    public event PropertyChangedEventHandler PropertyChanged;
    public DepartmentDetailsViewModel(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
        SaveDepartmentCommand = new Command(SaveDepartment);
        DeleteDepartmentCommand = new Command(DeleteDepartment);
    }
    private void SaveDepartment()
    {
        _departmentService.SaveDepartmentAsync(Department);
        Shell.Current.GoToAsync("..");
    }
    private void DeleteDepartment()
    {
        _departmentService.DeleteDepartmentAsync(Department.Name);
        Shell.Current.GoToAsync("..");
    }
    private void OpenDepartmentDetails(string name)
    {
        var route = $"{nameof(DepartmentDetailsPage)}?departmentName={name}";
        Shell.Current.GoToAsync(route);
    }
    public async Task LoadDepartmentAsync(string name)
    {
        Department = await _departmentService.GetDepartmentAsync(name);
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}