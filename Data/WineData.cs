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
        Wine AddWine(Wine wine);
        // Task<Wine> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        // void Insert(Wine Wine);
        // void Update(Wine Wine);
        // void Delete(Wine Wine);
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

        // public async Task<Wine> GetAsync(int id)
        // {
        //     return await _databaseContext.Wines
        //         .Include(e => e.Category)
        //         .Include(e => e.Task)
        //         .FirstOrDefaultAsync(c => c.Id == id);
        // }

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

        // public void Update(Wine wine)
        // {
        //     _databaseContext.Wines.Update(wine);
        // }

        // public void Delete(Wine wine)
        // {
        //     _databaseContext.Wines.Remove(wine);
        // }
    }
}
