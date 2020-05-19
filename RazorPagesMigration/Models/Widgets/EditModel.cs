using System.ComponentModel.DataAnnotations;
using RazorPagesMigration.Controllers;

namespace RazorPagesMigration.Models.Widgets
{
    public class EditModel
    {
        public EditModel()
        {
        }
        
        public EditModel(Widget widget)
        {
            Id = widget.Id;
            Name = widget.Name;
        }

        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}