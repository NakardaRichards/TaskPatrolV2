using System;

namespace TaskPatrolV2.Services
{
    public interface INotificationManager
    {
   
        void ShowNotification(string title, string message, DateTime notifyTime, string channelId = "default");
       
    }
}
