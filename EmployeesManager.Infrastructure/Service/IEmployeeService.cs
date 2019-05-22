using EmployeesManager.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Service
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task<EmployeeDto> GetByNIP(string nip);
        Task<IEnumerable<EmployeeDto>> BrowseAsync();
        Task AddEmployeeAsync(string nip, string firstName, string lastName, DateTime birthDate, string position, int salary);
        Task UpdateEmployeeAsync(Guid id, string nip, string firstName, string lastName, DateTime birthDate, string position, int salary);
        Task DeleteEmployeeAsync(Guid id);

    }
}
