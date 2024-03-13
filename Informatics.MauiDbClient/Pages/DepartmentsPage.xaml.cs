using Informatics.MauiDbClient.Models;
namespace Informatics.MauiDbClient.Pages;
public partial class DepartmentsPage : ContentPage
{
	public DepartmentsPage(DepartmentsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	private void OnDepartmentSelected(object sender, SelectionChangedEventArgs e)
	{
		var department = e.CurrentSelection.FirstOrDefault() as Department;
		if (department != null)
		{
			var viewModel = BindingContext as DepartmentsViewModel;
			viewModel?.OpenDepartmentDetailsCommand.Execute(department.Name);
		}
	}
	// Onappearing is called when the page is navigated to
	protected override void OnAppearing()
	{
		base.OnAppearing();
		// Refresh the list every time the page appears
		var viewModel = BindingContext as DepartmentsViewModel;
		viewModel?.RefreshCommand.Execute(null);
	}
}