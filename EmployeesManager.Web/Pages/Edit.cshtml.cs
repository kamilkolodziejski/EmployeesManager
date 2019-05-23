using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesManager.Infrastructure.Dto;
using EmployeesManager.Infrastructure.Service;

namespace EmployeesManager.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EditModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public EmployeeDto EmployeeDto { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeDto = await _employeeService.GetByIdAsync(id.Value);

            if (EmployeeDto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _employeeService.UpdateEmployeeAsync(EmployeeDto.Id, EmployeeDto.NIP, EmployeeDto.FirstName, EmployeeDto.LastName,
                                                    EmployeeDto.BirthDate, EmployeeDto.Position, EmployeeDto.Salary);
            
            return RedirectToPage("./Index");
        }
    }
}
