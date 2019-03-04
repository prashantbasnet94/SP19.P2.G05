using SP19.P05.Web.Features.Shared;

namespace SP19.P05.Web.Features.Customers
{
    public class CreateCustomerDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Address MailingAddress { get; set; }
    }
}