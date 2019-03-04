using SP19.P05.Web.Features.Customers;

namespace SP19.P05.Web.Features.Tables
{
    public class CustomerTableBill
    {
        public int TableBillId { get; set; }
        public virtual TableBill TableBill { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}