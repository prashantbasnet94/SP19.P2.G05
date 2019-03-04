using System.Collections.Generic;

namespace SP19.P05.Common.Features.Authorization
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<int> Roles { get; set; } = new List<int>();
    }
}