using Informatics.MauiDbClient.Pages;
namespace Informatics.MauiDbClient;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(EmployeeDetailsPage), typeof(EmployeeDetailsPage));
		Routing.RegisterRoute(nameof(DepartmentDetailsPage), typeof(DepartmentDetailsPage));
	}
}