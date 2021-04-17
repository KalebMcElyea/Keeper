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
        private readonly VaultsService _valServ;

        public ProfilesController(ProfilesService service, KeepsService keepServ, VaultsService valServ)
        {
            _service = service;
            _keepServ = keepServ;
            _valServ = valServ;
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

        [HttpGet("{id}/vaults")]
        public ActionResult<IEnumerable<Vault>> GetVaultsByProfileId(string id)
        {
            try
            {
                return Ok(_valServ.GetVaultsByProfileId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/vault")]
        public ActionResult<IEnumerable<VaultKeeperViewModel>> GetVaults(string id)
        {
            try
            {
                return Ok(_valServ.GetByProfileId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}