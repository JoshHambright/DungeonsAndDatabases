using DungeonsAndDatabases.Models.CharacterModels;
using DungeonsAndDatabases.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{
    public class CharacterController : ApiController
    {
        //Establish DB connection
        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            return characterService;
        }

        //CREATE
        //Create New Character
        [HttpPost]
        public async Task<IHttpActionResult> Character(CharacterCreate cha)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCharacterService();

            var result = await service.CreateCharacter(cha);

            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Get all Characters
        /// </summary>
        /// <returns>List of Characters</returns>
        //READ
        //Get All Characters
        [HttpGet]
        public async Task<IHttpActionResult> GetCharacter()
        {
            CharacterService characterService = CreateCharacterService();
            var character = await characterService.GetCharacter();
            return Ok(character);
        }

        //Get Character By ID
        [HttpGet]
        public async Task<IHttpActionResult> GetCharacter(int id)
        {
            CharacterService characterService = CreateCharacterService();
            var character = await characterService.GetCharacter(id);
            return Ok(character);
        }

        //Update a Character
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCharacter([FromUri] int id, [FromBody] CharacterEdit character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCharacterService();
            var credentials = await service.CheckCharCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.UpdateCharacter(id, character);
            if (result == false)
                return InternalServerError();
            return Ok();
        }

        //Delete a Character
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCharacter(int id)
        {
            var service = CreateCharacterService();
            var credentials = await service.CheckCharCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.DeleteCharacter(id);

            if (result == false)
                return InternalServerError();
            return Ok();
        }
    }
}
