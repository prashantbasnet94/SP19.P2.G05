using AutoMapper;
using SP19.P05.Common.Features.Authorization;

namespace SP19.P05.Web.Features.Authorization
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}