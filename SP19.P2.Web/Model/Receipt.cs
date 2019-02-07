using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class Receipt
    {

        public int ReceiptId { get; set; }
        public int LineItemId { get; set; }
        public int PaymentOptionId { get; set; }
        public int Total { get; set; }
        public DateTimeOffset DateOfPayment { get; set; }
        public int PaymentReferenceNumber { get; set; }
        public int PaymentAuthenticationNumber { get; set; }
        public int Table { get; set; }


    }
}
