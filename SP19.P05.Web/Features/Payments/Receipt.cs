using System;
using System.Collections.Generic;
using SP19.P05.Web.Features.LineItems;

namespace SP19.P05.Web.Features.Payments
{
    public class Receipt
    {
        public int Id { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();
        public int PaymentOptionId { get; set; }
        public virtual PaymentOption PaymentOption { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset DateOfPaymentUtc { get; set; }
        public string ReferenceNumber { get; set; }
        public string AuthNumber { get; set; }
    }
}