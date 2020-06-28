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

        Category AddCategory(Category category);
        Category Update(Category category);
        void Delete(Category category);

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
            while(true)
            {
                try
                {
                    return await _databaseContext.Categories
                                    .FirstOrDefaultAsync(c => c.Id == id);
                } catch {}
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _databaseContext.Categories.ToListAsync();
        }

        public Category AddCategory(Category category)
        {
            _databaseContext.Categories.Add(category);
            _databaseContext.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _databaseContext.Categories.Update(category);
            _databaseContext.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _databaseContext.Categories.Remove(category);
            _databaseContext.SaveChanges();

        }
    }
}
