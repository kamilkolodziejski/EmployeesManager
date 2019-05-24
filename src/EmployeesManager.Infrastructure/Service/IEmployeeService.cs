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
        Task<IEnumerable<EmployeeDto>> BrowseAsync();
        Task AddEmployeeAsync(EmployeeDto EmployeeDto);
        Task UpdateEmployeeAsync(EmployeeDto EmployeeDto);
        Task DeleteEmployeeAsync(Guid id);

    }
}
