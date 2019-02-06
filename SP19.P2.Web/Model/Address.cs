using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int StreetNumber { get; set; }
        [MaxLength(128)]
        public string StreetName { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(30)]
        public string State { get; set; }
        [MaxLength(5)]
        public int Zip { get; set; }

    }
}
