using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IEmployeeData
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetAsync(int id);
        System.Threading.Tasks.Task CommitAsync();
        void Insert(Employee Employee);
        System.Threading.Tasks.Task HasEmailAsync(string email);
        Task<Employee> GetByEmailAsync(string email);
        Task<Employee> GetByEmailPasswordAsync(string email, string password);
        void Update(Employee Employee);
        void Delete(Employee Employee);
    }
    public class EmployeeData : IEmployeeData
    {
        private AdmContext _databaseContext;

        public EmployeeData(AdmContext context)
        {
            _databaseContext = context;
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _databaseContext.Employees
                .AsNoTracking()
                .Include(e => e.Role)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _databaseContext.Employees.ToListAsync();
        }

        public async System.Threading.Tasks.Task HasEmailAsync(string email)
        {
            var Employee = await _databaseContext.Employees
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.Email == email);

            if (Employee != null)
            {
                throw new DuplicateWaitObjectException();
            }
        }

        public async Task<Employee> GetByEmailAsync(string email)
        {
            Employee a = await _databaseContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email);

            if (a != null)
                return a;
            else
                throw new UnauthorizedAccessException();
        }

        public void Insert(Employee Employee)
        {
            _databaseContext.Employees.Add(Employee);
        }

        public async Task<Employee> GetByEmailPasswordAsync(string email,
                                                            string password)
        {
            Employee a = await _databaseContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    c => c.Email == email &&
                    c.HashedPassword == password
                );

            if (a != null)
                return a;
            else
                throw new UnauthorizedAccessException();
        }

        public void Update(Employee Employee)
        {
            _databaseContext.Employees.Update(Employee);
        }

        public void Delete(Employee Employee)
        {
            _databaseContext.Employees.Remove(Employee);
        }
    }
}
