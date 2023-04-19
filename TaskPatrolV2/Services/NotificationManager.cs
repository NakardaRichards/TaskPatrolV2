
using TaskPatrolV2.Models;
using Plugin.LocalNotification;

namespace TaskPatrolV2.Services
{
    public class NotificationManager : INotificationManager
    {
        public void ShowNotification(string title, string subtitle, DateTime notifyTime, string description)
        {
            var request = new NotificationRequest
            {
                NotificationId = 1000,
                Title = title,
                Subtitle = subtitle,
                Description = description,
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = notifyTime,
                    NotifyRepeatInterval = TimeSpan.FromDays(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
    }
}