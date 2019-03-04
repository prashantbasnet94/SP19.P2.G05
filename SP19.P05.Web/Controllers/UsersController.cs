using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P05.Common.Features.Authorization;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Authorization;

namespace SP19.P05.Web.Controllers
{
    public class UsersController : ApiBase
    {
        private readonly UserManager<User> userManager;
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public UsersController(
            DataContext dataContext,
            IMapper mapper,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(CreateUserDto dto)
        {
            using (var transaction = await dataContext.Database.BeginTransactionAsync())
            {
                var roleIds = dto.Roles?.ToArray() ?? new int[0];
                var roles = await dataContext.Set<Role>().Where(x => roleIds.Contains(x.Id)).ToArrayAsync();
                if (roles.Any(x => x.Name == UserRoles.Customer))
                {
                    // there are a LOT more validation things to be done here and everywhere
                    // consider RFC 7807 output format
                    return BadRequest("cannot create customer here");
                }

                var entity = new User();
                mapper.Map(dto, entity);
                var identityResult = await userManager.CreateAsync(entity, dto.Password);
                if (!identityResult.Succeeded)
                {
                    return BadRequest(identityResult.Errors);
                }

                foreach (var role in roles)
                {
                    await userManager.AddToRoleAsync(entity, role.Name);
                }

                var result = new UserDto();
                result.Id = entity.Id;
                result.Email = entity.Email;
                result.Roles = roles.Select(x => new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                transaction.Commit();
                return result;
            }
        }
    }
}