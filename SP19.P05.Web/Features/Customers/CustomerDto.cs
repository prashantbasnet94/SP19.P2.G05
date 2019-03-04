using SP19.P05.Web.Features.Shared;

namespace SP19.P05.Web.Features.Customers
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Address MailingAddress { get; set; }
    }
}