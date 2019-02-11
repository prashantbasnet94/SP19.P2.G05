using System.Collections.Generic;
using SP19.P03.Web.Features.Authorization;
using SP19.P03.Web.Features.Payments;
using SP19.P03.Web.Features.Shared;

namespace SP19.P03.Web.Features.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public Address MailingAddress { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PaymentOption> PaymentOptions { get; set; } = new List<PaymentOption>();
    }
}