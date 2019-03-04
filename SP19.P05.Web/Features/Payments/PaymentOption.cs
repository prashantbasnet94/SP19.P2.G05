using SP19.P05.Web.Features.Customers;
using SP19.P05.Web.Features.Shared;

namespace SP19.P05.Web.Features.Payments
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string TokenizedCardReference { get; set; }
        public Address BillingAddress { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}