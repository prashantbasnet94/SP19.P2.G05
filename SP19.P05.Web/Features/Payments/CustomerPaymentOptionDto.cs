using SP19.P05.Web.Features.Shared;

namespace SP19.P05.Web.Features.Payments
{
    public class CustomerPaymentOptionDto
    {
        public int Id { get; set; }
        public Address BillingAddress { get; set; }
        public int CustomerId { get; set; }
        public string Nickname { get; set; }
        public string TokenizedCardReference { get; set; }
    }
}