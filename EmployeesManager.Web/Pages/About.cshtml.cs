using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeesManager.Web.Pages
{
    public class AboutModel : PageModel
    {
        public AboutModel()
        {
        }
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
