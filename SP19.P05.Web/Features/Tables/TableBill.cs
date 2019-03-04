using System;
using System.Collections.Generic;

namespace SP19.P05.Web.Features.Tables
{
    public class TableBill
    {
        public int Id { get; set; }
        public DateTimeOffset StartDateUtc { get; set; }
        public DateTimeOffset? EndDateUtc { get; set; }
        public int TableId { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<TableFoodItem> TableFoodItems { get; set; } = new List<TableFoodItem>();
        public virtual ICollection<CustomerTableBill> Customers { get; set; } = new List<CustomerTableBill>();
    }
}