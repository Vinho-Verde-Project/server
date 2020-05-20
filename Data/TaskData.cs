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
        void Insert(Models.Task Task);
        void Update(Models.Task Task);
        void Delete(Models.Task Task);
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

        public void Insert(Models.Task Task)
        {
            _databaseContext.Tasks.Add(Task);
        }

        public void Update(Models.Task Task)
        {
            _databaseContext.Tasks.Update(Task);
        }

        public void Delete(Models.Task Task)
        {
            _databaseContext.Tasks.Remove(Task);
        }
    }
}
