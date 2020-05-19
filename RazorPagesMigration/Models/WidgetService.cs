using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace RazorPagesMigration.Controllers
{
    public class WidgetService
    {
        public int PageSize => 25;
        public static List<Widget> Widgets { get; set; }
             = new List<Widget>();
        
        public IPagedList<Widget> GetAll(in int page)
        {
            return Widgets.ToPagedList(page, PageSize);
        }

        public Widget Add(string name)
        {
            var w = new Widget
            {
                Id = (Widgets.Any() 
                    ? Widgets.Max(x => x.Id) 
                    : 0) + 1,
                Name = name
            };
            
            Widgets.Add(w);
            return w;
        }

        public Widget Get(in int id)
        {
            var i = id;
            return Widgets.Find(w => w.Id == i);
        }

        public Widget Update(int id, string name)
        {
            var w = Get(id);
            w.Name = name;
            return w;
        }

        public void Remove(int id)
        {
            Widgets.RemoveAll(x => x.Id == id);
        }
    }
}