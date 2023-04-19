
using TaskPatrolV2.ViewModels;
namespace TaskPatrolV2.Views;

public partial class AddTaskPage : ContentPage
{
    public AddTaskPage(AddTaskPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}