using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.PlayerModels;
using DungeonsAndDatabases.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{
    public class PlayerController : ApiController
    { 
        public PlayerService  CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playerService = new PlayerService(userId);
            return playerService;
        }
        // Create 
        public IHttpActionResult CreatePlayer(PlayerCreate player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerService();
            if (!service.CreatePlayer(player).Result)
                return InternalServerError();
            return Ok();
        }
        //Read
        [HttpGet]
        public IHttpActionResult GetPlayers()
        {
            PlayerService playerService = CreatePlayerService();
            var players = playerService.GetPlayers();
            return Ok(players);
        }
        [HttpGet]
        public IHttpActionResult GetPlayerByID(Guid id)
        {
            PlayerService playerService = CreatePlayerService();
            var player = playerService.GetPlayerById(id);
            if (player == null)
                return NotFound();
            return Ok(player);
        }
        
        
      
        //Updated
        [HttpPut]
        public IHttpActionResult UpdatePlayer([FromUri] string name, [FromBody] PlayerEdit player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerService();
            if (!service.UpdatePlayer(name, player).Result)
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeletePlayer(string name)
        {
            var service = CreatePlayerService();
            if (!service.DeletePlayer(name).Result)
                return InternalServerError();
            return Ok();
        }
    }
}
