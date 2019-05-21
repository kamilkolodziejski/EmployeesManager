using EmployeesManager.Core.Model;
using System.Threading.Tasks;

namespace EmployeesManager.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(string NIP);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
    }
}