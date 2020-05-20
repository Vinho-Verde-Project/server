using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IRoleData
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Role Role);
        void Update(Role Role);
        void Delete(Role Role);
    }
    public class RoleData : IRoleData
    {
        private AdmContext _databaseContext;

        public RoleData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await _databaseContext.Roles
                .AsNoTracking()
                .Include(e => e.Permission)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _databaseContext.Roles.ToListAsync();
        }

        public void Insert(Role Role)
        {
            _databaseContext.Roles.Add(Role);
        }

        public void Update(Role Role)
        {
            _databaseContext.Roles.Update(Role);
        }

        public void Delete(Role Role)
        {
            _databaseContext.Roles.Remove(Role);
        }
    }
}
