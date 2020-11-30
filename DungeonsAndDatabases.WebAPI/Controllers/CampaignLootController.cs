using DungeonsAndDatabases.Models.Loot;
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
    public class CampaignLootController : ApiController
    {

        private CampaignLootService CreateCampaignLootService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var CampaignLootService = new CampaignLootService(userId);
            return CampaignLootService;
        }
        /// <summary>
        /// Add Campaign Loot to Campaign.
        /// </summary>
        [HttpPost]
        public async Task<IHttpActionResult> Post(LootCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignLootService();
            var credentials = await service.CheckCreateCredentials(model.CampaignID);
            if (credentials == false)
                return Unauthorized();
            var result = await service.CreateCampaignLoot(model);

            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Get all Loot collected by Players.
        /// </summary>
        [HttpGet]
        public async Task<IHttpActionResult> GetCampaignLoot()
        {
            CampaignLootService campaignLootService = CreateCampaignLootService();
            var campaignLoot = await campaignLootService.GetAllCampaignLoot();
            return Ok(campaignLoot);
        }
        /// <summary>
        /// Find a Loot item by ID.
        /// </summary>
        /// <param name="id">The ID of your Campaign.</param>
        [HttpGet]
        public async Task<IHttpActionResult> GetLootItem(int id)
        {
            CampaignLootService campaignLootService = CreateCampaignLootService();
            var credentials = await campaignLootService.CheckDMCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var loot = await campaignLootService.GetCampaignLootByID(id);
            if (loot == null)
                return NotFound();
            return Ok(loot);
        }
        /// <summary>
        /// Update Loot item in Campaign.
        /// </summary>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCampaignLootItem([FromUri]int id,[FromBody]LootUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignLootService();
            var credentials = await service.CheckDMCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.UpdateCampaignLoot(id, model);
            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Delete a Loot Item.
        /// </summary>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCampaignLoot(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignLootService();
            var credentials = await service.CheckDMCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.DeleteCampaignLoot(id);
            if (result == false)
                return InternalServerError();
            return Ok();
        }
    }
}
