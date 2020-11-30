using DungeonsAndDatabases.Models.MembershipModels;
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
    public class MembershipController : ApiController
    {

        private MembershipService CreateMembershipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var membershipService = new MembershipService(userId);
            return membershipService;

        }
        /// <summary>
        /// Create a Membership
        /// </summary>
        /// <param name="membership"></param>
        /// <returns>Creates a membership for a character in a campaign</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(MembershipCreate membership)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMembershipService();
            var credentials = await service.CheckDMCredentials(membership.CampaignID);
            if (credentials == false)
                return Unauthorized();
            var result = await service.CreateMembership(membership);

            if (result == false)
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Get Memberships
        /// </summary>
        /// <returns>Displays all memberships a player is a part of</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetMemberships()
        {
            MembershipService membershipService = CreateMembershipService();

            var memberships = await membershipService.GetMemberships();
            return Ok(memberships);
        }
        /// <summary>
        /// Get Membership by Keys 
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="characterId"></param>
        /// <returns>Displays a specific entry in the membership table</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetMembership(int campaignId, int characterId)
        {
            MembershipService membershipService = CreateMembershipService();
            var credentials = await membershipService.CheckGetCredentials(campaignId, characterId);
            if (credentials == false)
                return Unauthorized();
            var membership = await membershipService.GetMembershipById(campaignId, characterId);
            
            if (membership == null)
                return NotFound();
            return Ok(membership);
        }
        /// <summary>
        /// Delete a membership
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="characterId"></param>
        /// <returns>Removes a specific membership</returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMembership(int campaignId, int characterId)
        {
            MembershipService membershipService = CreateMembershipService();
            var credentials = await membershipService.CheckDMCredentials(campaignId);
            if (credentials == false)
                return Unauthorized();
            var membership = await membershipService.DeleteMembership(campaignId, characterId);
            if (membership == false)
                return NotFound();
            return Ok(membership);
        }
    }
}
