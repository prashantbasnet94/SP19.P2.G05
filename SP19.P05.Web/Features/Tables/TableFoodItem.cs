using SP19.P05.Web.Features.LineItems;

namespace SP19.P05.Web.Features.Tables
{
    public class TableFoodItem
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public uint QuantityOrdered { get; set; }
        public decimal? Discount { get; set; }
        public int TableBillId { get; set; }
        public virtual TableBill TableBill { get; set; }
    }
}