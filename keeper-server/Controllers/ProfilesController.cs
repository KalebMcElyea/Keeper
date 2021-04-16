using System;
using System.Collections.Generic;
using keeper_server.Models;
using keeper_server.Service;
using Microsoft.AspNetCore.Mvc;

namespace keeper_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _service;
        private readonly KeepsService _keepServ;

        public ProfilesController(ProfilesService service, KeepsService keepServ)
        {
            _service = service;
            _keepServ = keepServ;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                return Ok(_service.GetProfileById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}/keeps")]
        public ActionResult<IEnumerable<Keep>> GetKeepsByProfileId(string id)
        {
            try
            {
                return Ok(_keepServ.GetKeepsByProfileId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}