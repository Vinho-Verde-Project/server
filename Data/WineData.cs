using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IWineData
    {
        Task<IEnumerable<Wine>> GetAllAsync();
        Task<Wine> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Wine Wine);
        void Update(Wine Wine);
        void Delete(Wine Wine);
    }
    public class WineData : IWineData
    {
        private AdmContext _databaseContext;

        public WineData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Wine> GetAsync(int id)
        {
            return await _databaseContext.Wines
                .Include(e => e.Category)
                .Include(e => e.Task)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Wine>> GetAllAsync()
        {
            return await _databaseContext.Wines.ToListAsync();
        }

        public void Insert(Wine Wine)
        {
            _databaseContext.Wines.Add(Wine);
        }

        public void Update(Wine Wine)
        {
            _databaseContext.Wines.Update(Wine);
        }

        public void Delete(Wine Wine)
        {
            _databaseContext.Wines.Remove(Wine);
        }
    }
}
