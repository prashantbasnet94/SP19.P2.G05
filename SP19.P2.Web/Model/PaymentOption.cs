using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class PaymentOption
    {
        [Key]
        public int PaymentOptionId { get; set; }
        [MaxLength(64)]
        public string Nickname { get; set; } //Examples: cash, mastercard, visa, debit, credit etc
        [MaxLength(128)]
        public string TokenizedCardReference { get; set; } //Also known as transaction ID. See: https://www.paypal.com/us/smarthelp/article/what-are-reference-transactions-(tokenization)-ts1469
        
        //Foriegn keys
        public int BillingAddressId { get; set; }
    }
}
