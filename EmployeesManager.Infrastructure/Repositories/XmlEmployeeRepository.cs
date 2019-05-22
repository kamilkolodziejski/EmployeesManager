using EmployeesManager.Core.Model;
using EmployeesManager.Core.Repositories;
using EmployeesManager.Infrastructure.XmlDataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Repositories
{
    public class XmlEmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeesStore _store;

        public XmlEmployeeRepository(IEmployeesStore store)
        {
            _store = store;
        }

        public async Task AddAsync(Employee employee)
        {
            _store.Employees.Add(employee);
            _store.Save();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Employee>> BrowseAsync()
            => await Task.FromResult(_store.Employees.ToList());

        public async Task<Employee> GetAsync(string NIP)
            => await Task.FromResult(_store.Employees.Where(x => x.NIP == NIP).SingleOrDefault());

        public async Task<Employee> GetAsync(Guid id)
            => await Task.FromResult(_store.Employees.Where(x => x.Id == id).SingleOrDefault());

        public async Task RemoveAsync(Guid id)
        {
            var employee = _store.Employees.SingleOrDefault(x => x.Id == id);
            _store.Employees.Remove(employee);
            _store.Save();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employeeFromStore = _store.Employees.SingleOrDefault(x => x.Id == employee.Id);
            employeeFromStore = employee;
            _store.Save();
            await Task.CompletedTask;
        }
    }
}
