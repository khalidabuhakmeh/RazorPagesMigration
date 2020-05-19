using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMigration.Controllers;

namespace RazorPagesMigration.Pages.Widgets
{
    public class Create : PageModel
    {
        [BindProperty, Required]
        public string Name { get; set; }

        // public void OnGet() { }
        
        public IActionResult OnPost([FromServices]WidgetService service)
        {
            if (ModelState.IsValid)
            {
                var widget = service.Add(Name);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}