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
        public int Customer { get; set; }
        //Don't know if we should use DateTime or DateTimeOffet
        //Have DateTimeOffset for now.
        [Required]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        public DateTimeOffset EndTime { get; set; }
        public int TableFoodItemId { get; set; }

        //Foriegn Keys
        public int TableId { get; set; } //What table are they sitting at
        
        
    }
}
