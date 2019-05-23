using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeesManager.Web.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string EmployeeDtoId { get; set; }

        public bool ShowEmployeeDtoId => !string.IsNullOrEmpty(EmployeeDtoId);

        public void OnGet()
        {
            EmployeeDtoId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
