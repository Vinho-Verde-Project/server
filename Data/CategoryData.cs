using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface ICategoryData
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Category Category);
        void Update(Category Category);
        void Delete(Category Category);
    }
    public class CategoryData : ICategoryData
    {
        private AdmContext _databaseContext;

        public CategoryData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _databaseContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _databaseContext.Categories.ToListAsync();
        }

        public void Insert(Category Category)
        {
            _databaseContext.Categories.Add(Category);
        }

        public void Update(Category Category)
        {
            _databaseContext.Categories.Update(Category);
        }

        public void Delete(Category Category)
        {
            _databaseContext.Categories.Remove(Category);
        }
    }
}
