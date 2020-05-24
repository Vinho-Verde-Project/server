using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IProductData
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Product Product);
        void Update(Product Product);
        void Delete(Product Product);
    }
    public class ProductData : IProductData
    {
        private AdmContext _databaseContext;

        public ProductData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _databaseContext.Products
                .Include(e => e.Category)
                .Include(e => e.Step)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _databaseContext.Products.ToListAsync();
        }

        public void Insert(Product Product)
        {
            _databaseContext.Products.Add(Product);
        }

        public void Update(Product Product)
        {
            _databaseContext.Products.Update(Product);
        }

        public void Delete(Product Product)
        {
            _databaseContext.Products.Remove(Product);
        }
    }
}