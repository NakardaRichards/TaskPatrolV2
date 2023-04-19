using TaskPatrolV2.ViewModels;
namespace TaskPatrolV2.Views;
using Plugin.LocalNotification;

public partial class Home : ContentPage
{
    private HomeViewModel _viewMode;
    public Home(HomeViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetTaskCommand.Execute(null);
    }

   
}