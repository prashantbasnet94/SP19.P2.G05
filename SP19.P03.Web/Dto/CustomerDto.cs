using SP19.P03.Web.Features.Authorization;
using SP19.P03.Web.Features.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P03.Web.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public Address MailingAddress { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        

    }
}
