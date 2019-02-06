using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class TableFoodItem
    {
        [Key]
        public int TableFoodItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int AmountOrdered { get; set; }
        public int Discount { get; set; } //Might have to change this FLOAT depending on approach
    }
}