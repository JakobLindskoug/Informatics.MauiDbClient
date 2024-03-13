namespace Informatics.MauiDbClient.Pages;
[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeDetailsPage : ContentPage
{
	private int _employeeId;
	public int EmployeeId
	{
		get => _employeeId;
		set
		{
			_employeeId = value;
			LoadEmployee(_employeeId);
		}
	}
	public EmployeeDetailsPage(EmployeeDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	private void LoadEmployee(int employeeId)
	{
		((EmployeeDetailsViewModel)BindingContext).LoadDepartments();
		((EmployeeDetailsViewModel)BindingContext).LoadEmployee(employeeId);
	}
}
