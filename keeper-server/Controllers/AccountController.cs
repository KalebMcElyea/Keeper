using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper_server.Models;
using keeper_server.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeper_server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly Service.ProfilesService _ps;
        private readonly Service.VaultsService _valService;
        private readonly Service.KeepsService _kService;

        public AccountController(ProfilesService ps, VaultsService valService, KeepsService kService)
        {
            _ps = ps;
            _valService = valService;
            _kService = kService;
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



        [HttpGet("keeps")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Keep>>> GetKeepsByAccountId()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_kService.GetKeepsByAccountId(userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("vaults")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsByAccountId()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                IEnumerable<Vault> vaults = _valService.GetVaultsByAccountId(userInfo.Id);
                return Ok(_valService.GetVaultsByAccountId(userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}