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
        Step AddStep(Step step);
        Step Update(Step step);
        void Delete(Step step);
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
                .Include(t => t.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Step>> GetAllAsync()
        {
            return await _databaseContext.Steps.ToListAsync();
        }

        public Step AddStep(Step step)
        {
            _databaseContext.Steps.Add(step);
            _databaseContext.SaveChanges();
            return step;
        }

        public Step Update(Step step)
        {
            _databaseContext.Steps.Update(step);
            _databaseContext.SaveChanges();
            return step;
        }

        public void Delete(Step step)
        {
            _databaseContext.Steps.Remove(step);
            _databaseContext.SaveChanges();
        }
    }
}
