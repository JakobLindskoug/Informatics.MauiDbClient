using System.Reflection;
using Informatics.MauiDbClient.Contexts;
using Informatics.MauiDbClient.Pages;
using Informatics.MauiDbClient.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace Informatics.MauiDbClient;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
		.UseMauiApp<App>()
		.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
		});
		// Add appsettings.json to configuration
		var assembly = Assembly.GetExecutingAssembly();
		string appsettingsFileName = "Informatics.MauiDbClient.appsettings.json";
		using (var stream = assembly.GetManifestResourceStream(appsettingsFileName))
		{
			if (stream != null)
			{
				builder.Configuration.AddJsonStream(stream);
			}
		}

		// Add DbContext to services
		builder.Services.AddDbContext<UniversityContext>(options =>
		options.UseSqlServer(
		builder.Configuration.GetConnectionString("ProgramDatabase")
		)
	);

		builder.Services.AddTransient<IEmployeeService, EmployeeService>();
		builder.Services.AddTransient<IDepartmentService, DepartmentService>();
		builder.Services.AddTransient<EmployeesViewModel>();
		builder.Services.AddTransient<EmployeeDetailsViewModel>();
		builder.Services.AddTransient<DepartmentsViewModel>();
		builder.Services.AddTransient<DepartmentDetailsViewModel>();
		builder.Services.AddSingleton<EmployeesPage>();
		builder.Services.AddSingleton<EmployeeDetailsPage>();
		builder.Services.AddSingleton<DepartmentsPage>();
		builder.Services.AddSingleton<DepartmentDetailsPage>();



#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
