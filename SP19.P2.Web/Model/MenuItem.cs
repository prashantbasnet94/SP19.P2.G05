using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        public int Price { get; set; }

        public string Picture { get; set; }
        public List<MenuJoinMenuItem> MenuJoinMenuItems { get; set; }
    }
}
