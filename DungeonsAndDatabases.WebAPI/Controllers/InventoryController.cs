using DungeonsAndDatabases.Models.EquipmentModels;
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
    public class InventoryController : ApiController
    {
        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var equipmentService = new EquipmentService(userId);
            return equipmentService;
        }
        /// <summary>
        /// Creates a new equipment item in a characters inventory
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Ok if successful, Bad Request if model is invalid, Unathorized if character isn't owned by you, Internal server error if some other problem writing it</returns>
        //Create Equipment Item
        [HttpPost]
        public async Task<IHttpActionResult> CreateEquipmentAsync(EquipmentCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEquipmentService();
            var credentials = await service.CheckCharacterCredentials(model.ChararcterID);
            if (credentials == false)
                return Unauthorized();
            var result = await service.CreateEquipment(model);

            if (result == false)
                return InternalServerError();
            return Ok();
        }
        //Get All Equipment for a Character.
        /// <summary>
        /// Gets all the equipment for a specified character
        /// </summary>
        /// <param name="characterid"></param>
        /// <returns>A list of equipment</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAllEquipmentForACharacterAsync(int characterid)
        {
            EquipmentService service = CreateEquipmentService();
            var credentials = await service.CheckCharacterCredentials(characterid);
            if (credentials == false)
                return Unauthorized();
            var inventory = await service.GetEquipmentByCharacterId(characterid);
            if (inventory == null)
                return NotFound();
            return Ok(inventory);
        }
        /// <summary>
        /// Gets the details on a specific equipment Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>an Equipment object</returns>
        //Get equipment item by ID (if owned by player)
        [HttpGet]
        public async Task<IHttpActionResult> GetEquipmentByIDAsync(int id)
        {
            EquipmentService service = CreateEquipmentService();
            var credentials = await service.CheckEquipmentCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var equipment = await service.GetEquipmentByEquipmentID(id);
            if (equipment == null)
                return NotFound();
            return Ok(equipment);
        }

        /// <summary>
        /// Update an equipment item 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Ok if successful</returns>
        //Update an equipment Item
        [HttpPut]
        public async Task<IHttpActionResult> UpdateEquipmentAsync([FromUri] int id, [FromBody] EquipmentUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEquipmentService();
            var credentials = await service.CheckEquipmentCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.UpdateEquipment(id, model);
            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Deletes a specific piece of equipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200 if ok</returns>
        //Delete an Item
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteEquipmentAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEquipmentService();
            var credentials = await service.CheckEquipmentCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.DeleteEquipment(id);
            if (result == false)
                return InternalServerError();
            return Ok();
        }

    }
}
