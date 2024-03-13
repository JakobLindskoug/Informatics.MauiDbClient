using Informatics.MauiDbClient.Models;
namespace Informatics.MauiDbClient.Pages;
public partial class EmployeesPage : ContentPage
{
	public EmployeesPage(EmployeesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	// This method is a workaround for the lack of direct support in CollectionView
	// for binding a Command to the SelectionChanged event.
	// Normally, in MVVM, we prefer to bind commands directly in XAML to keep the logic
	// within the ViewModel. However, CollectionView's SelectionChanged event doesn't
	// natively support binding to a Command. Therefore, we handle the event in the code-behind
	// and then delegate the logic to the ViewModel.
	// This approach allows us to maintain a separation of concerns where the View (code-behind)
	// is only responsible for UI interactions, and the ViewModel handles the business logic.
	private void OnEmployeeSelected(object sender, SelectionChangedEventArgs e)
	{
		var selectedEmployee = e.CurrentSelection.FirstOrDefault() as Employee;
		if (selectedEmployee != null)
		{
			var viewModel = BindingContext as EmployeesViewModel;
			viewModel?.OpenEmployeeDetailsCommand.Execute(selectedEmployee.Id);
		}
	}
	// Used to refresh the list of employees when the page appears
	// This is necessary because the list of employees may change when the user navigates
	// back to this page after editing an employee.
	protected override void OnAppearing()
	{
		base.OnAppearing();
		// Refresh the list every time the page appears
		var viewModel = BindingContext as EmployeesViewModel;
		viewModel?.RefreshCommand.Execute(null);
	}
}