using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class TableBill
    {
        [Key]
        public int TableBillId { get; set; }
        public Customer Customer { get; set; }
        //Don't know if we should use DateTime or DateTimeOffet
        //Have DateTimeOffset for now.
        [Required]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        public DateTimeOffset EndTime { get; set; }
        public TableFoodItem TableFoodItem { get; set; }

        //Foriegn Keys
        public Table Table { get; set; } //What table are they sitting at
        
        public List<TableFoodItem> TableFoodItems { get; set; }
        
        public List<Customer> Customers { get; set; }
    }
}
