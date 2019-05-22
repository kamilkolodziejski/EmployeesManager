using AutoMapper;
using EmployeesManager.Infrastructure.XmlStore;
using EmployeesManager.Infrastructure.Dto;
using System;
using System.Collections.Generic;
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

        public async Task AddEmployeeAsync(string nip, string firstName, string lastName, DateTime birthDate, string position, int salary)
        {
            var employee = new Employee(Guid.NewGuid(), nip, firstName, lastName, birthDate, position, salary);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> BrowseAsync()
        {
            var employees = await _employeeRepository.BrowseAsync();
            var employeesDTO = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDTO;
        }

        public async Task DeleteEmployeeAsync(Guid id)
            => await _employeeRepository.RemoveAsync(id);

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> GetByNIP(string nip)
        {
            var employee = await _employeeRepository.GetAsync(nip);
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task UpdateEmployeeAsync(Guid id, string nip, string firstName, string lastName, DateTime birthDate, string position, int salary)
        {
            var employee = await _employeeRepository.GetAsync(id);
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.SetBirthDate(birthDate);
            employee.Position = position;
            employee.SetSalary(salary);
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}