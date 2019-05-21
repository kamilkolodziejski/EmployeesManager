using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Service
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(string NIP, string FirstName, string LastName, string BirthDate, string Position, int Salary);
    }
}
