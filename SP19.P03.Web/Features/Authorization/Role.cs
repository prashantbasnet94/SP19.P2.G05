using System.Collections.Generic;

namespace SP19.P03.Web.Features.Authorization
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> Users { get; set; } = new List<UserRole>();
    }
}