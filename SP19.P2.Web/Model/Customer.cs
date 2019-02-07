﻿using System;
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
        public int UserId { get; set; }
        public int PaymentOption { get; set; }
        public int MailingAddressId { get; set; }
    }
}
