using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskPatrolV2.Models;

namespace TaskPatrolV2.Services
{
    public class TaskService : ITaskService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskPatrolV4.db");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<MyTasks>();
            }
        }


        public async Task<int> AddTask(MyTasks myTasks)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(myTasks);
        }


        public async Task<List<MyTasks>> GetTask()
        {
            await SetUpDb();
            var myTasks = await _dbConnection.Table<MyTasks>().ToListAsync();
            return myTasks;
        }

        public async Task<int> DeleteTask(MyTasks myTasks)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(myTasks);
        }

        public async Task<int> UpdateTask(MyTasks myTasks)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(myTasks);
        }


    }
}
