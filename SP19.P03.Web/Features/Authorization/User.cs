using System.Collections.Generic;

namespace SP19.P03.Web.Features.Authorization
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}