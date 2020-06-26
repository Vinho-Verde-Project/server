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
        Employee AddEmployee(Employee employee);
        System.Threading.Tasks.Task HasEmailAsync(string email);
        Task<Employee> GetByEmailAsync(string email);
        Task<Employee> GetByEmailPasswordAsync(string email, string password);
        Employee Update(Employee employee);
        void Delete(Employee employee);
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
            while(true){
                try{
                    return await _databaseContext.Employees
                        .AsNoTracking()
                        .Include(e => e.Role)
                        .FirstOrDefaultAsync(c => c.Id == id);
                } catch {}
            }
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

        public Employee AddEmployee(Employee employee)
        {
            _databaseContext.Employees.Add(employee);
            _databaseContext.SaveChanges();
            return employee;
        }

        public async Task<Employee> GetByEmailPasswordAsync(string email,
                                                            string password)
        {
            return await _databaseContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    c => c.Email == email &&
                    c.HashedPassword == password
                );

            // if (a != null)
            //     return a;
            // else
            //     throw new UnauthorizedAccessException();
        }

        public Employee Update(Employee employee)
        {
            _databaseContext.Employees.Update(employee);
            _databaseContext.SaveChanges();
            return employee;
        }

        public void Delete(Employee employee)
        {
            _databaseContext.Employees.Remove(employee);
            _databaseContext.SaveChanges();
        }
    }
}
