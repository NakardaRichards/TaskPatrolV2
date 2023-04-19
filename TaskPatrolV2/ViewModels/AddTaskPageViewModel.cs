using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using SQLite;
using System.Runtime.CompilerServices;
using TaskPatrolV2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskPatrolV2.Views;
using TaskPatrolV2.Services;


namespace TaskPatrolV2.ViewModels

{

   
    [QueryProperty(nameof(TaskDetail), "TaskDetail")]
    public partial class AddTaskPageViewModel : ObservableObject
    {
       

        [ObservableProperty]
        private MyTasks _taskDetail = new MyTasks();


        
        private readonly ITaskService _taskService;
        public AddTaskPageViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            
        }

        private int response;
        [RelayCommand]
        public async void AddUpdateTask()
        {
            try
            {
                if (string.IsNullOrEmpty(TaskDetail.Description))
                {
                    throw new Exception("Description is required.");
                }

                if (TaskDetail.Date == null)
                {
                    throw new Exception("Date is required.");
                }

                if (TaskDetail.Time == null)
                {
                    throw new Exception("Time is required.");
                }

                if (string.IsNullOrEmpty(TaskDetail.Category))
                {
                    throw new Exception("Category is required.");
                }

                if (TaskDetail.TaskId > 0)
                {
                    response = await _taskService.UpdateTask(TaskDetail);
                }
                else
                {
                    response = await _taskService.AddTask(new Models.MyTasks
                    {
                        Description = TaskDetail.Description,
                        Date = TaskDetail.Date,
                        Time = TaskDetail.Time,
                        Category = TaskDetail.Category
                    });
                }

                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Task Saved", "Your Task Has Been Saved", "OK");
                    await Shell.Current.Navigation.PopModalAsync();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Oh No!", "Something went wrong while adding the task", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }



        public ICommand CancelCommand => new Command(async () =>
        {
            await Shell.Current.Navigation.PopModalAsync();
        });
    }
}
