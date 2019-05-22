using EmployeesManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Service
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetByIdAsync(Guid id);
        Task<EmployeeDTO> GetByNIP(string nip);
        Task<IEnumerable<EmployeeDTO>> BrowseAsync();
        Task AddEmployeeAsync(string nip, string firstName, string lastName, string birthDate, string position, int salary);
        Task UpdateEmployeeAsync(Guid id, string nip, string firstName, string lastName, string birthDate, string position, int salary);
        Task DeleteEmployeeAsync(Guid id);

    }
}
