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
        //Get all campaigns
        [HttpGet]
        public async Task <IHttpActionResult> GetAllCampaigns()
        {
            CampaignService campaignService = CreateCampaignService();
            var campaigns = await campaignService.GetCampaigns();
            return Ok(campaigns);
        }
        
        //Get Campaign by ID
        [HttpGet]
        public async Task <IHttpActionResult> GetCampaignByID(int id)
        {
            CampaignService campaignService = CreateCampaignService();
            var campaign = await campaignService.GetCampaignById(id);
            if (campaign == null)
                return NotFound();
            return Ok(campaign);
        }

        //Update a Campaign
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCampaign([FromUri] int id, [FromBody] CampaignUpdate campaign)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignService();
           
            var result = await service.UpdateCampaign(id,campaign);
            if (result == false)
                return InternalServerError();
            return Ok();
        }

        //Delete a Campaign
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCampaign(int id)
        {
            var service = CreateCampaignService();
            var campaign = await service.DeleteCampaign(id);
            if (campaign == false)
                return InternalServerError();
            return Ok();
        }
    }
}
