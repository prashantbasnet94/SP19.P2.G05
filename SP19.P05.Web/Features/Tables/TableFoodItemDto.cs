namespace SP19.P05.Web.Features.Tables
{
    public class TableFoodItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public uint QuantityOrdered { get; set; }
        public decimal? Discount { get; set; }
        public int TableBillId { get; set; }
        public string MenuItemName { get; set; }
    }
}