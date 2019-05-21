﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesManager.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeesManager.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        public ContactModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
