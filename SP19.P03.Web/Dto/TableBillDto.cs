using SP19.P03.Web.Features.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P03.Web.Dto
{
    public class TableBillDto
    {
        public int Id { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public DateTimeOffset StartDateUtc { get; set; }
        public DateTimeOffset? EndDateUtc { get; set; }
        public int TableId { get; set; }
    }
}
