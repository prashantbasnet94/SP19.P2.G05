using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public User RelatedUser { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public Address MailingAddress { get; set; }
    }
}
