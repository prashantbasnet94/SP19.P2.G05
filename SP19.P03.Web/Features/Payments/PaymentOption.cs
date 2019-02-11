using SP19.P03.Web.Features.Authorization;
using SP19.P03.Web.Features.Shared;

namespace SP19.P03.Web.Features.Payments
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string TokenizedCardReference { get; set; }
        public Address BillingAddress { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}