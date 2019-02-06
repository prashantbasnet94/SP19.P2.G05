using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        public int PerItemCost { get; set; }
        public int Amount { get; set; }
    }
}
