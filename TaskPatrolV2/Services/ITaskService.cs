using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPatrolV2.Models;

namespace TaskPatrolV2.Services
{
    public interface ITaskService
    {
        Task<List<MyTasks>> GetTask();
        Task<int> AddTask(MyTasks myTasks);
        Task<int> DeleteTask(MyTasks myTasks);
        Task<int> UpdateTask(MyTasks myTasks);
    }



}
