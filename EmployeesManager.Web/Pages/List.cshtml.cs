using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeesManager.Infrastructure.DTO;
using EmployeesManager.Infrastructure.Service;

namespace EmployeesManager.Web.Pages
{
    public class ListModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public ListModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeDTO> Employees { get;set; }

        public async Task OnGetAsync()
        {
            Employees = await _employeeService.BrowseAsync();
        }
    }
}
