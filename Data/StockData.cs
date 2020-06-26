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
        Stock AddStock(Stock stock);
        Stock Update(Stock stock);
        void Delete(Stock stock);
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
            while(true){
                try {
                    return await _databaseContext.Stocks
                        .FirstOrDefaultAsync(c => c.Id == id);
                } catch {}
            }
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _databaseContext.Stocks.ToListAsync();
        }

        public Stock AddStock(Stock stock)
        {
            _databaseContext.Stocks.Add(stock);
            _databaseContext.SaveChanges();
            return stock;
        }

        public Stock Update(Stock stock)
        {
            _databaseContext.Stocks.Update(stock);
            _databaseContext.SaveChanges();
            return stock;
        }

        public void Delete(Stock stock)
        {
            _databaseContext.Stocks.Remove(stock);
            _databaseContext.SaveChanges();
        }
    }
}
