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
        public IHttpActionResult Post(CampaignCreate campaign)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignService();

            if (!service.CreateCampaign(campaign).Result)
                return InternalServerError();
            return Ok();

        }
        //Get all campaigns
        [HttpGet]
        public IHttpActionResult GetAllCampaigns()
        {
            CampaignService campaignService = CreateCampaignService();
            var campaigns = campaignService.GetCampaigns();
            return Ok(campaigns);
        }
        
        //Get Campaign by ID
        [HttpGet]
        public IHttpActionResult GetCampaignByID(int id)
        {
            CampaignService campaignService = CreateCampaignService();
            var campaign = campaignService.GetCampaignById(id);
            if (campaign == null)
                return NotFound();
            return Ok(campaign);
        }

        //Update a Campaign
        [HttpPut]
        public IHttpActionResult UpdateCampaign([FromUri] int id, [FromBody] CampaignUpdate campaign)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignService();

            if (!service.UpdateCampaign(id,campaign).Result)
                return InternalServerError();
            return Ok();
        }

        //Delete a Campaign
        [HttpDelete]
        public IHttpActionResult DeleteCampaign(int id)
        {
            var service = CreateCampaignService();
            if (!service.DeleteCampaign(id).Result)
                return InternalServerError();
            return Ok();
        }
    }
}
