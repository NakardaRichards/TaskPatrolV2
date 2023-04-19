using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskPatrolV2.Models;
using TaskPatrolV2.Services;
using TaskPatrolV2.Views;
using System.Collections.ObjectModel;
using SQLite;

namespace TaskPatrolV2.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public static List<MyTasks> TasksListForSearch { get; private set; } = new List<MyTasks>();
        public ObservableCollection<MyTasks> Tasks { get; set; } = new ObservableCollection<MyTasks>();
        public string Email { get; internal set; }

        private readonly ITaskService _taskService;

        public HomeViewModel(ITaskService taskService)
        {
            _taskService = taskService;

        }
        public int TaskCount => Tasks.Count;
  

       
        [RelayCommand]
        public async void GetTask()
        {
            Tasks.Clear();
            var taskList = await _taskService.GetTask();
            if (taskList?.Count > 0)
            {
                taskList = taskList.OrderBy(f => f.FullTask).ToList();
                foreach (var task in taskList)
                {
                    Tasks.Add(task);
                  
                }
                TasksListForSearch.Clear();
                TasksListForSearch.AddRange(taskList);
                OnPropertyChanged(nameof(TaskCount));
            }
        }

        [RelayCommand]
        public async void AddUpdateTask()
        {
            await AppShell.Current.GoToAsync(nameof(AddTaskPage));
        }


        public string GetCountdown(DateTime dueDate)
        {
            TimeSpan timeLeft = dueDate - DateTime.Now;
            int daysLeft = (int)timeLeft.TotalDays;
            return daysLeft.ToString();
        }
        [RelayCommand]
        public async void EditTask(MyTasks myTasks)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("TaskDetail", myTasks);
            await AppShell.Current.GoToAsync(nameof(AddTaskPage), navParam);
        }

        [RelayCommand]
        public async void DeleteTask(MyTasks myTasks)
        {
            var delResponse = await _taskService.DeleteTask(myTasks);
            if (delResponse > 0)
            {
                GetTask();
                OnPropertyChanged(nameof(TaskCount));
            }
        }

        [RelayCommand]
        public async void DisplayAction(MyTasks myTasks)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("TaskDetail", myTasks);
                await AppShell.Current.GoToAsync(nameof(AddTaskPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _taskService.DeleteTask(myTasks);
                if (delResponse > 0)
                {
                    GetTask();
                    OnPropertyChanged(nameof(TaskCount));
                }
            }
        }
    }
}
