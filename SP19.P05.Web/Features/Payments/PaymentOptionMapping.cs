using AutoMapper;

namespace SP19.P05.Web.Features.Payments
{
    public class PaymentOptionMapping : Profile
    {
        public PaymentOptionMapping()
        {
            CreateMap<PaymentOption, CustomerPaymentOptionDto>()
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); // don't allow Id's to be assigned by DTOs
        }
    }
}