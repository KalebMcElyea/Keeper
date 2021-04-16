using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper_server.Models;
using keeper_server.Service;
using Microsoft.AspNetCore.Mvc;

namespace keeper_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly Service.ProfilesService _ps;

        public AccountController(ProfilesService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}