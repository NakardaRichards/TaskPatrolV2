using TaskPatrolV2.Views;		
namespace TaskPatrolV2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
        Routing.RegisterRoute(nameof(Home), typeof(Home));

    }
}
