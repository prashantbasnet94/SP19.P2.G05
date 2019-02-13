using SP19.P03.Web.Features.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P03.Web.Dto
{
    public class CustomerPaymentOptionsDto
    {


        public int Id { get; set; }
        public string Nickname { get; set; }
        public string TokenizedCardReference { get; set; }
        public Address BillingAddress { get; set; }
        public int UserId { get; set; }
        
    }
}
