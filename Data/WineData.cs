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
        Wine AddWine(Wine wine);
        Wine Update(Wine wine);
        void Delete(Wine wine);
    }
    public class WineData : IWineData
    {
        private readonly AdmContext _databaseContext;

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

        public Wine AddWine(Wine wine)
        {
            _databaseContext.Wines.Add(wine);
            _databaseContext.SaveChanges();
            return wine;
        }

        public Wine Update(Wine wine)
        {
            _databaseContext.Wines.Update(wine);
            _databaseContext.SaveChanges();
            return wine;
        }

        public void Delete(Wine wine)
        {
            _databaseContext.Wines.Remove(wine);
            _databaseContext.SaveChanges();
        }
    }
}
