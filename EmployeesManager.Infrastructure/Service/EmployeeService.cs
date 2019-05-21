using EmployeesManager.Core.Model;
using EmployeesManager.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task AddEmployeeAsync(string NIP, string FirstName, string LastName, string BirthDate, string Position, int Salary)
        {
            var employee = new Employee(Guid.NewGuid(), "dwasd", "dwads", "dwadsa", DateTime.Now, "dwads", 43243);
            await _employeeRepository.AddAsync(employee);
        }
    }
}