using EmployeesManager.Infrastructure.XmlStore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.XmlStore
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