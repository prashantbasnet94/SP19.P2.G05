using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
       
        public string TableType { get; set; } //Example: Booth or Table or Bar
        public int NumberOfSeats { get; set; }
        public List<TableBill> TableBills { get; set; }
    }
}
