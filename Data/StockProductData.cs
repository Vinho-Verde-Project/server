using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api.Data
{
    public interface IStockProductData
    {
        Task<IEnumerable<StockProduct>> GetAllAsync();
        Task<IEnumerable<StockProduct>> GetProductsAsync(int id);
        Task<IEnumerable<StockProduct>> GetStocksAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        StockProduct AddStockProduct(StockProduct stockProduct);
        StockProduct Update(StockProduct stockProduct);
        void Delete(StockProduct stockProduct);
    }
    public class StockProductData : IStockProductData
    {
        private AdmContext _databaseContext;

        public StockProductData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockProduct>> GetProductsAsync(int id)
        {
            try{
                return await _databaseContext.StockProducts
                        .Where(e => e.StockId == id)
                        .ToListAsync();
            } catch (Exception error) {
                Console.WriteLine(error);
                return null;
            }
        }

        public async Task<IEnumerable<StockProduct>> GetStocksAsync(int id)
        {
           while(true){
               try{
                  return await _databaseContext.StockProducts
                           .Where(e => e.ProductId == id)
                           .ToListAsync();
               } catch {
                  
               }
            }
        }

        public async Task<IEnumerable<StockProduct>> GetAllAsync()
        {
            return await _databaseContext.StockProducts.ToListAsync();
        }

        public StockProduct AddStockProduct(StockProduct stockProduct)
        {
            _databaseContext.StockProducts.Add(stockProduct);
            _databaseContext.SaveChanges();
            return stockProduct;
        }

        public StockProduct Update(StockProduct stockProduct)
        {
            _databaseContext.StockProducts.Update(stockProduct);
            _databaseContext.SaveChanges();
            return stockProduct;
        }

        public void Delete(StockProduct stockProduct)
        {
            _databaseContext.StockProducts.Remove(stockProduct);
            _databaseContext.SaveChanges();
        }
    }
}
