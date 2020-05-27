using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface ITaskData
    {
        Task<IEnumerable<Models.Task>> GetAllAsync();
        Task<Models.Task> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        Models.Task AddTask(Models.Task task);
        Models.Task Update(Models.Task task);
        void Delete(Models.Task task);
    }
    public class TaskData : ITaskData
    {
        private AdmContext _databaseContext;

        public TaskData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Models.Task> GetAsync(int id)
        {
            return await _databaseContext.Tasks
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Models.Task>> GetAllAsync()
        {
            return await _databaseContext.Tasks.ToListAsync();
        }

        public Models.Task AddTask(Models.Task task)
        {
            _databaseContext.Tasks.Add(task);
            _databaseContext.SaveChanges();
            return task;
        }

        public Models.Task Update(Models.Task task)
        {
            _databaseContext.Tasks.Update(task);
            _databaseContext.SaveChanges();
            return task;
        }

        public void Delete(Models.Task task)
        {
            _databaseContext.Tasks.Remove(task);
            _databaseContext.SaveChanges();
        }
    }
}
