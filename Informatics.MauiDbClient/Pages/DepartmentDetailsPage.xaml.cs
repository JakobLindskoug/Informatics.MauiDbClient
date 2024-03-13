namespace Informatics.MauiDbClient.Pages;
[QueryProperty(nameof(DepartmentName), "departmentName")]
public partial class DepartmentDetailsPage : ContentPage
{
	private string _departmentName;
	public string DepartmentName
	{
		get => _departmentName;
		set
		{
			_departmentName = value;
			LoadDepartment();
		}
	}
	public DepartmentDetailsPage(DepartmentDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	private void LoadDepartment()
	{
		(BindingContext as DepartmentDetailsViewModel)?.LoadDepartmentAsync(_departmentName);
	}
}