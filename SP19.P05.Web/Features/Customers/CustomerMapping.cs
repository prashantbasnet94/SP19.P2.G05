using AutoMapper;

namespace SP19.P05.Web.Features.Customers
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.Email, o => o.MapFrom(x => x.User.Email)) // get email directly
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); // don't allow Id's to be assigned by DTOs

            CreateMap<CreateCustomerDto, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}