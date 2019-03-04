using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SP19.P05.Web.Data;
using SP19.P05.Web.Features.Authorization;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SP19.P05.Web.Controllers
{
    public class AuthenticationController : ApiBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthenticationController(SignInManager<User> signInManager, DataContext dataContext, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<SignInResult>> Login(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.Username);
            if (user == null)
            {
                return BadRequest(new SignInResult());
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            await signInManager.SignInAsync(user, false, "Password");
            return Ok(result);
        }
    }
}