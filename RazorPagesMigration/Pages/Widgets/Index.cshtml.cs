using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMigration.Controllers;
using X.PagedList;

namespace RazorPagesMigration.Pages.Widgets
{
    public class Index : PageModel
    {
        private readonly WidgetService service;

        public Index(WidgetService service)
        {
            this.service = service;
        }
        
        [BindProperty(Name = "page", SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        
        public IPagedList<Widget> All { get; set; }
            = Enumerable.Empty<Widget>().ToPagedList();
        
        public void OnGet()
        {
            All = service.GetAll(PageNumber);
        }

        public IActionResult OnPostDelete(int id)
        {
            service.Remove(id);
            return RedirectToPage("Index");
        }
    }
}