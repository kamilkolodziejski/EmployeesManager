using AutoMapper;
using EmployeesManager.Infrastructure.XmlRepository;
using EmployeesManager.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeesManager.Core.Domain;

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

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee(employeeDto.Id, employeeDto.NIP, employeeDto.FirstName, employeeDto.LastName,
                                            employeeDto.BirthDate, employeeDto.Position, employeeDto.Salary);

            await _employeeRepository.AddAsync(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> BrowseAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDto;
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            if(employee == null)
            {
                throw new EmployeeManagerException("Pracownik nie istnieje");
            }
            await _employeeRepository.RemoveAsync(employee);
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetAsync(id);
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.GetAsync(employeeDto.Id);
            if(employee == null)
            {
                throw new EmployeeManagerException("Pracownik nie istnieje");
            }
            employee.SetNIP(employeeDto.NIP);
            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.SetBirthDate(employeeDto.BirthDate);
            employee.Position = employeeDto.Position;
            employee.SetSalary(employeeDto.Salary);
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}