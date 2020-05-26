using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IStockData
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Stock Stock);
        void Update(Stock Stock);
        void Delete(Stock Stock);
    }
    public class StockData : IStockData
    {
        private AdmContext _databaseContext;

        public StockData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Stock> GetAsync(int id)
        {
            return await _databaseContext.Stocks
                .Include(e => e.Employee)
                .Include(e => e.StockProducts)
                .ThenInclude(e => e.Product)
                .Include(e => e.StockWines)
                .ThenInclude(e => e.Wine)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _databaseContext.Stocks.ToListAsync();
        }

        public void Insert(Stock Stock)
        {
            _databaseContext.Stocks.Add(Stock);
        }

        public void Update(Stock Stock)
        {
            _databaseContext.Stocks.Update(Stock);
        }

        public void Delete(Stock Stock)
        {
            _databaseContext.Stocks.Remove(Stock);
        }
    }
}
