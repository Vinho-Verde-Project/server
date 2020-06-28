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
        Permission AddPermission(Permission permission);
        Permission Update(Permission permission);
        void Delete(Permission permission);
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
            while(true)
            {
                try
                {
                    return await _databaseContext.Permissions
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.Id == id);
                } catch {}
            }
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _databaseContext.Permissions.ToListAsync();
        }

        public Permission AddPermission(Permission permission)
        {
            _databaseContext.Permissions.Add(permission);
            _databaseContext.SaveChanges();
            return permission;
        }

        public Permission Update(Permission permission)
        {
            _databaseContext.Permissions.Update(permission);
            _databaseContext.SaveChanges();
            return permission;
        }

        public void Delete(Permission permission)
        {
            _databaseContext.Permissions.Remove(permission);
            _databaseContext.SaveChanges();
        }
    }
}
