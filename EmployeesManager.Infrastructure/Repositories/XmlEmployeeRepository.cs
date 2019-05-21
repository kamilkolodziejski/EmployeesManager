using EmployeesManager.Core.Model;
using EmployeesManager.Core.Repositories;
using EmployeesManager.Infrastructure.XmlDataStore;
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

        public async Task<Employee> GetAsync(string NIP)
            => await Task.FromResult(_store.Employees.Where(x => x.NIP == NIP).SingleOrDefault());

        public async Task UpdateAsync(Employee employee)
        {
            var employeeFromStore = _store.Employees.SingleOrDefault(x => x.Id == employee.Id);
            employeeFromStore = employee;
            _store.Save();
            await Task.CompletedTask;
        }
    }
}
