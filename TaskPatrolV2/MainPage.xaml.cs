using TaskPatrolV2.Views;

namespace TaskPatrolV2;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
 

    }

   async void OnGoClicked(object sender, EventArgs e)
	{
      
        await AppShell.Current.GoToAsync(nameof(Home));
    }
}

