namespace SP19.P03.Web.Features.Authorization
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}