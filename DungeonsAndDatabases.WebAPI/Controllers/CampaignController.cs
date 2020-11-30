using DungeonsAndDatabases.Models.CampaignModels;
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
    public class CampaignController : ApiController
    {
        private CampaignService CreateCampaignService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var campaignService = new CampaignService(userId);
            return campaignService;
        }
        /// <summary>
        /// Create a new Campaign.
        /// </summary>
        public async Task<IHttpActionResult> Post(CampaignCreate campaign)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignService();
            var result =  await service.CreateCampaign(campaign);
            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Gets all campaigns in the databases.
        /// </summary>
        [HttpGet]
        public async Task <IHttpActionResult> GetAllCampaigns()
        {
            CampaignService campaignService = CreateCampaignService();
            var campaigns = await campaignService.GetCampaigns();
            return Ok(campaigns);
        }
        /// <summary>
        /// Find a Campaign by ID.
        /// </summary>
        /// <param name="id">The ID of your Campaign.</param>
        [HttpGet]
        public async Task<IHttpActionResult> GetCampaignByID(int id)
        {
            CampaignService campaignService = CreateCampaignService();
            var campaign = await campaignService.GetCampaignById(id);
            if (campaign == null)
                return NotFound();
            return Ok(campaign);
        }
        /// <summary>
        /// Update a campaign in the database.
        /// </summary>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCampaign([FromUri] int id, [FromBody] CampaignUpdate campaign)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignService();
            var credentials = await service.CheckDMCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.UpdateCampaign(id,campaign);
            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Delete a campaign in the database.
        /// </summary>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCampaign(int id)
        {
            var service = CreateCampaignService();
            var credentials = await service.CheckDMCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var campaign = await service.DeleteCampaign(id);
            if (campaign == false)
                return InternalServerError();
            return Ok();
        }
    }
}
