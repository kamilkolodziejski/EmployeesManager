﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeesManager.Infrastructure.Dto;
using EmployeesManager.Web.Models;
using EmployeesManager.Infrastructure.Service;

namespace EmployeesManager.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeDto> EmployeeDto { get;set; }

        public async Task OnGetAsync()
        {
            EmployeeDto = await _employeeService.BrowseAsync();
        }
    }
}
