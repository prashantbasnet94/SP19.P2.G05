using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class MenuJoinMenuItem
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int MenutItemId { get; set; }
        public MenuItem MenuItem { get; set; }

    }
}
