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
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _kService;
        public KeepsController(KeepsService kService)
        {
            _kService = kService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Keep>> GetAll()
        {
            try
            {
                return Ok(_kService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Keep> GetbyId(int id)
        {
            try
            {
                return Ok(_kService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Keep>> Post([FromBody] Keep newKeep)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newKeep.CreatorId = userInfo.Id;
                Keep created = _kService.Create(newKeep);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Keep>> Edit(int id, [FromBody] Keep editData)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editData.Id = id;
                editData.Creator = userInfo;
                editData.CreatorId = userInfo.Id;
                return Ok(_kService.Edit(editData, userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_kService.Delete(id, userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}