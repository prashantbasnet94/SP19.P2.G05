using System.Linq;
using AutoMapper;
using SP19.P05.Common.Features.Authorization;
using SP19.P05.Web.Features.Customers;

namespace SP19.P05.Web.Features.Authorization
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Roles, o => o.MapFrom(x => x.Roles.Select(y => y.Role))); // get around joining table
            
            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Roles, o => o.Ignore());


            CreateMap<CreateCustomerDto, User>();
        }
    }
}