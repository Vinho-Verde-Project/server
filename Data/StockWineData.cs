using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api.Data
{
    public interface IStockWineData
    {
        Task<IEnumerable<StockWine>> GetAllAsync();
        Task<IEnumerable<StockWine>> GetWinesAsync(int id);
        Task<IEnumerable<StockWine>> GetStocksAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        StockWine AddStockWine(StockWine stockWine);
        StockWine Update(StockWine stockWine);
        void Delete(StockWine stockWine);
    }
    public class StockWineData : IStockWineData
    {
        private AdmContext _databaseContext;

        public StockWineData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockWine>> GetWinesAsync(int id)
        {
            while (true){
                try{
                    return await _databaseContext.StockWines
                            .Where(e => e.StockId == id)
                            .ToListAsync();
                } catch {}
            }
        }

        public async Task<IEnumerable<StockWine>> GetStocksAsync(int id)
        {
           while(true){
               try{
                  return await _databaseContext.StockWines
                           .Where(e => e.WineId == id)
                           .ToListAsync();
               } catch {
                  
               }
            }
        }

        public async Task<IEnumerable<StockWine>> GetAllAsync()
        {
            return await _databaseContext.StockWines.ToListAsync();
        }

        public StockWine AddStockWine(StockWine stockWine)
        {
            _databaseContext.StockWines.Add(stockWine);
            _databaseContext.SaveChanges();
            return stockWine;
        }

        public StockWine Update(StockWine stockWine)
        {
            _databaseContext.StockWines.Update(stockWine);
            _databaseContext.SaveChanges();
            return stockWine;
        }

        public void Delete(StockWine stockWine)
        {
            _databaseContext.StockWines.Remove(stockWine);
            _databaseContext.SaveChanges();
        }
    }
}
