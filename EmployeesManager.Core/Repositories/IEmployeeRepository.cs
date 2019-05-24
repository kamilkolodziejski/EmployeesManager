using EmployeesManager.Infrastructure.XmlRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.XmlRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task RemoveAsync(Employee employee);
    }
}