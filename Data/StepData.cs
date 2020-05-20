using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IStepData
    {
        Task<IEnumerable<Step>> GetAllAsync();
        Task<Step> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Step Step);
        void Update(Step Step);
        void Delete(Step Step);
    }
    public class StepData : IStepData
    {
        private AdmContext _databaseContext;

        public StepData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Step> GetAsync(int id)
        {
            return await _databaseContext.Steps
                .Include(e => e.Employee)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Step>> GetAllAsync()
        {
            return await _databaseContext.Steps.ToListAsync();
        }

        public void Insert(Step Step)
        {
            _databaseContext.Steps.Add(Step);
        }

        public void Update(Step Step)
        {
            _databaseContext.Steps.Update(Step);
        }

        public void Delete(Step Step)
        {
            _databaseContext.Steps.Remove(Step);
        }
    }
}
