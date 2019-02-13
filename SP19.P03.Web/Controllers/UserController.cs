using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP19.P03.Web.Data;
using SP19.P03.Web.Dto;
using SP19.P03.Web.Features.Authorization;

namespace SP19.P03.Web.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(User user)
        {

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto();
        }



        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
