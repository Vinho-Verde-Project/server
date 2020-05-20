using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IPermissionData
    {
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<Permission> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Permission Permission);
        void Update(Permission Permission);
        void Delete(Permission Permission);
    }
    public class PermissionData : IPermissionData
    {
        private AdmContext _databaseContext;

        public PermissionData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Permission> GetAsync(int id)
        {
            return await _databaseContext.Permissions
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _databaseContext.Permissions.ToListAsync();
        }

        public void Insert(Permission Permission)
        {
            _databaseContext.Permissions.Add(Permission);
        }

        public void Update(Permission Permission)
        {
            _databaseContext.Permissions.Update(Permission);
        }

        public void Delete(Permission Permission)
        {
            _databaseContext.Permissions.Remove(Permission);
        }
    }
}
