using AutoMapper;
using EmployeesManager.Core.Model;
using EmployeesManager.Core.Repositories;
using EmployeesManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task AddEmployeeAsync(string nip, string firstName, string lastName, string birthDate, string position, int salary)
        {
            var employee = new Employee(Guid.NewGuid(), nip, firstName, lastName, DateTime.ParseExact(birthDate,"yyyy-MM-dd",CultureInfo.InvariantCulture), position, salary);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task<IEnumerable<EmployeeDTO>> BrowseAsync()
        {
            var employees = await _employeeRepository.BrowseAsync();
            var employeesDTO = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
            return await Task.FromResult(employeesDTO);
        }

        public async Task DeleteEmployeeAsync(Guid id)
            => await _employeeRepository.RemoveAsync(id);

        public Task<EmployeeDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetByNIP(string nip)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEmployeeAsync(Guid id, string nip, string firstName, string lastName, string birthDate, string position, int salary)
        {
            var employee = await _employeeRepository.GetAsync(id);
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.BirthDate = DateTime.ParseExact(birthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            employee.Position = position;
            employee.Salary = salary;
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}