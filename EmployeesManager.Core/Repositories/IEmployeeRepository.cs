using EmployeesManager.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(Guid id);
        Task<Employee> GetAsync(string NIP);
        Task<IEnumerable<Employee>> BrowseAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task RemoveAsync(Guid id);
    }
}