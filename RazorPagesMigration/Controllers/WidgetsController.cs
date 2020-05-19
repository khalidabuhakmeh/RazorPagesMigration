using Microsoft.AspNetCore.Mvc;
using RazorPagesMigration.Models.Widgets;

namespace RazorPagesMigration.Controllers
{
    [Route("[controller]-mvc")]
    public class WidgetsController : Controller
    {
        private readonly WidgetService service;

        public WidgetsController(WidgetService service)
        {
            this.service = service;
        }
        
        [HttpGet, Route("")]
        public IActionResult Index(int page = 1)
        {
            var all = service.GetAll(page);
            return View(new IndexModel(all));
        }

        [HttpGet, Route("new")]
        public IActionResult New()
        {
            return View(new EditModel());
        }
        

        [HttpPost, Route("create")]
        public IActionResult Create([FromForm] EditModel request)
        {
            if (ModelState.IsValid)
            {
                // widget service
                service.Add(request.Name);
                return RedirectToAction("Index");
            }

            return View("New", request);
        }

        [HttpGet, Route("{id:int}")]
        public IActionResult Edit(int id)
        {
            var widget = service.Get(id);
            return View(new EditModel(widget));
        }

        [HttpPost, Route("{id:int}")]
        public IActionResult Update(int id, [FromForm] EditModel request)
        {
            if (ModelState.IsValid)
            {
                var widget = service.Update(id, request.Name);
                return RedirectToAction("Index");
            }

            request.Id = id;
            return View("edit", request);
        }

        [HttpPost, Route("{id:int}/delete")]
        public IActionResult Delete(int id)
        {
            service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}