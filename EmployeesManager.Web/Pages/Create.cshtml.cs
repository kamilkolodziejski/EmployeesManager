using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeesManager.Infrastructure.Service;
using EmployeesManager.Infrastructure.Dto;

namespace EmployeesManager.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public CreateModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmployeeDto EmployeeDto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _employeeService.AddEmployeeAsync(EmployeeDto);
            return RedirectToPage("./Employees");
        }
    }
}