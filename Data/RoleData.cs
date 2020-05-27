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
        Role AddRole(Role role);
        Role Update(Role role);
        void Delete(Role role);
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

        public Role AddRole(Role role)
        {
            _databaseContext.Roles.Add(role);
            _databaseContext.SaveChanges();
            return role;
        }

        public Role Update(Role role)
        {
            _databaseContext.Roles.Update(role);
            _databaseContext.SaveChanges();
            return role;
        }

        public void Delete(Role role)
        {
            _databaseContext.Roles.Remove(role);
            _databaseContext.SaveChanges();
        }
    }
}
