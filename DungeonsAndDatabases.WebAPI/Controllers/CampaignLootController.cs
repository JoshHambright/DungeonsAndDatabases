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

        [HttpGet]
        public async Task<IHttpActionResult> GetCampaignLoot()
        {
            CampaignLootService campaignLootService = CreateCampaignLootService();
            var campaignLoot = await campaignLootService.GetAllCampaignLoot();
            return Ok(campaignLoot);
        }

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
        //Update Campaign Loot
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
        //Delete Campaign Loot
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
