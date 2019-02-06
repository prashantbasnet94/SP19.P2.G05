using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public LineItem LineItem { get; set; }
        public int Total { get; set; }
        public DateTimeOffset DateOfPayment { get; set; }
        public int PaymentReferenceNumber { get; set; }
        public int PaymentAuthenticationNumber { get; set; }

        //Foriegn Key
        public List<LineItem> LineItems { get; set; }

        public Table Table { get; set; } //What table were the guests at?

        public User Server { get; set; } //Who was in charge of table?

        public List<PaymentOption> PaymentOptions { get; set; }
    }
}
