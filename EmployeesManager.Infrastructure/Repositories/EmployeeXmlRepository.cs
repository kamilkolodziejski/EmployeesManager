using EmployeesManager.Core.Model;
using EmployeesManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Repositories
{
    public class EmployeeXmlRepository : GenericXmlRepository<Employee>, IEmployeeRepository
    {
        public EmployeeXmlRepository(string path) : base(path)
        {
        }

        public async Task AddAsync(Employee employee)
        {
            _store.Add(employee);
            Save();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Employee>> BrowseAsync()
            => await Task.FromResult(_store.ToList());

        public async Task<Employee> GetAsync(string NIP)
            => await Task.FromResult(_store.Where(x => x.NIP == NIP).SingleOrDefault());

        public async Task<Employee> GetAsync(Guid id)
            => await Task.FromResult(_store.Where(x => x.Id == id).SingleOrDefault());

        public async Task RemoveAsync(Guid id)
        {
            var employee = _store.SingleOrDefault(x => x.Id == id);
            _store.Remove(employee);
            Save();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employeeFromStore = _store.SingleOrDefault(x => x.Id == employee.Id);
            employeeFromStore = employee;
            Save();
            await Task.CompletedTask;
        }
    }
}
