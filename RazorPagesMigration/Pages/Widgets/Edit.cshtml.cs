using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMigration.Controllers;

namespace RazorPagesMigration.Pages.Widgets
{
    public class Edit : PageModel
    {
        private readonly WidgetService service;

        public Edit(WidgetService service)
        {
            this.service = service;
        }
        
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        
        [BindProperty, Required]
        public string Name { get; set; }
        
        public IActionResult OnGet()
        {
            var widget = service.Get(Id);

            if (widget == null)
                return NotFound();
            
            Name = widget.Name;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                service.Update(Id, Name);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}