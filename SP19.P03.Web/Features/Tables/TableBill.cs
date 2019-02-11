using System;
using System.Collections.Generic;
using SP19.P03.Web.Features.Customers;

namespace SP19.P03.Web.Features.Tables
{
    public class TableBill
    {
        public int Id { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public DateTimeOffset StartDateUtc { get; set; }
        public DateTimeOffset? EndDateUtc { get; set; }
        public int TableId { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<TableFoodItem> TableFoodItems { get; set; } = new List<TableFoodItem>();
    }
}