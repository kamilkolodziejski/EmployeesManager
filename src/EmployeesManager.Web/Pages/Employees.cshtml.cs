using System;
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
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<EmployeeDto> EmployeeDto { get;set; }
        public string NameCurrentFilter { get; set; }
        public string NipCurrentFilter { get; set; }
        public string PositionCurrentFilter { get; set; }

        public async Task OnGetAsync(string lastNameFilter, string nipFilter, string positionFilter)
        {

            EmployeeDto = await _employeeService.BrowseAsync();
            NameCurrentFilter = lastNameFilter;
            NipCurrentFilter = nipFilter;
            PositionCurrentFilter = positionFilter;


            IEnumerable<EmployeeDto> employeesQuery = EmployeeDto;
            if (!String.IsNullOrEmpty(lastNameFilter))
                employeesQuery = employeesQuery.Where(e => !String.IsNullOrEmpty(e.LastName) && e.LastName.ToUpper().Contains(lastNameFilter.ToUpper()));
            if (!String.IsNullOrEmpty(nipFilter))
                employeesQuery = employeesQuery.Where(e => !String.IsNullOrEmpty(e.NIP) && e.NIP.ToUpper().Contains(nipFilter.ToUpper()));
            if (!String.IsNullOrEmpty(positionFilter))
                employeesQuery = employeesQuery.Where(e => !String.IsNullOrEmpty(e.Position) && e.Position.ToUpper().Contains(positionFilter.ToUpper()));

            EmployeeDto = employeesQuery.ToList();
        }

    }
}
