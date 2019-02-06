using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [MaxLength(6)]
        public string Name { get; set; } //3 different menus Lunch, Dinner, Desert

        public List<MenuItem> MenuItems { get; set; }
    }
}
