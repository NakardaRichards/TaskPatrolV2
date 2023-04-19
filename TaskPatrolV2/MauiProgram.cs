using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;
using TaskPatrolV2.Services;
using TaskPatrolV2.ViewModels;
using TaskPatrolV2.Views;
using Firebase;
using Firebase.Analytics;
namespace TaskPatrolV2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            FirebaseOptions options = new FirebaseOptions.Builder()
              .SetApplicationId("")
              .SetApiKey("")
              .SetProjectId("")
              .SetStorageBucket("")
              .Build();

            if (FirebaseApp.Instance == null)
            {
                FirebaseApp app = FirebaseApp.InitializeApp(Android.App.Application.Context, options);
            }

           

            var builder = MauiApp.CreateBuilder();
                builder
                   .UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                   .ConfigureFonts(fonts =>
   {
       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
       fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
   });



            builder.Services.AddSingleton<ITaskService, TaskService>();
            builder.Services.AddSingleton<INotificationManager, NotificationManager>();

            //Views Registration
            builder.Services.AddSingleton<Home>();
            builder.Services.AddTransient<AddTaskPage>();


            
            //View Modles 
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddTransient<AddTaskPageViewModel>();

            return builder.Build();
        }
    }
}
