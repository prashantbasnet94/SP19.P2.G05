using SP19.P05.Web.Features.Payments;

namespace SP19.P05.Web.Features.LineItems
{
    public class LineItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}