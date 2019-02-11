using System.Collections.Generic;
using SP19.P03.Web.Features.LineItems;

namespace SP19.P03.Web.Features.Menus
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}