using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SP19.P2.Web.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }

        //public int AddressId { get; set; }
        public MailingAddress Address { get; set; }

       
      
        public List<UserRole> UserRoles { get; set; } //If User has multiple roles.

    }
}
