
using Plugin.LocalNotification;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPatrolV2.Services;

namespace TaskPatrolV2.Models
{
    public class MyTasks
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Category { get; set; }

        [Ignore]
        public string FullTask => $"{Description}";

        [Ignore]
        public TimeSpan Countdown
        {
            get
            {
                DateTime taskDate = Date + Time;
                TimeSpan countdown = taskDate - DateTime.Now;

                if (countdown <= TimeSpan.Zero)
                {
                    var request = new NotificationRequest
                    {
                        NotificationId = 1000,
                        Title = $"Task Expired: {Description}",
                        Subtitle = "Best Task Manager",
                        Description = "View Now",
                        BadgeNumber = 42,
                        Schedule = new NotificationRequestSchedule
                        {
                            NotifyTime = DateTime.Now.AddSeconds(5),
                            NotifyRepeatInterval = TimeSpan.FromDays(1)
                        }
                    };
                    LocalNotificationCenter.Current.Show(request);

                    return TimeSpan.Zero;
                }

                return countdown < TimeSpan.Zero ? TimeSpan.Zero : countdown;
            }
        }
    }
}


