﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeesManager.Infrastructure.Dto;
using EmployeesManager.Infrastructure.Service;

namespace EmployeesManager.Web.Pages
{
    public class EmployeeDetailsModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeDetailsModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

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
    }
}