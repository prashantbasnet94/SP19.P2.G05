using SP19.P03.Web.Features.LineItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P03.Web.Dto
{
    public class TableFoodItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public uint QuantityOrdered { get; set; }
        public decimal? Discount { get; set; }
        public int TableBillId { get; set; }
    }
}
