using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeesManager.Infrastructure.Service;

namespace EmployeesManager.Web.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        public AboutModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
            _employeeService.AddEmployeeAsync("123", "dwadsa", "dwasdaw", "dwada", "dwasda", 54324324);
        }
    }
}
