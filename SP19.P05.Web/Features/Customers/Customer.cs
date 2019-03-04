using System.Collections.Generic;
using SP19.P05.Web.Features.Authorization;
using SP19.P05.Web.Features.Payments;
using SP19.P05.Web.Features.Shared;
using SP19.P05.Web.Features.Tables;

namespace SP19.P05.Web.Features.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public Address MailingAddress { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CustomerTableBill> TableBills { get; set; } = new List<CustomerTableBill>();
        public virtual ICollection<PaymentOption> PaymentOptions { get; set; } = new List<PaymentOption>();
    }
}