using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class MailingAddress
    {
        [Key]
        public int MailingAddressId { get; set; }
        
        public string Address { get; set; }
        
        public string OwnedType { get; set; }

    }
}
