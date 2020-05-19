using System.Collections.Generic;
using RazorPagesMigration.Controllers;

namespace RazorPagesMigration.Models.Widgets
{
    public class IndexModel
    {
        public IEnumerable<Widget> All { get; }

        public IndexModel(IEnumerable<Widget> all)
        {
            All = all;
        }
    }
}