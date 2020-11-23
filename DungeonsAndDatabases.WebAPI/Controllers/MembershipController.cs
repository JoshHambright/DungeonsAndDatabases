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
        [HttpPost]
        public async Task<IHttpActionResult> Post(MembershipCreate membership)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMembershipService();

            var result = await service.CreateMembership(membership);

            if (result == false)
                return InternalServerError();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMemberships()
        {
            MembershipService membershipService = CreateMembershipService();
            var memberships = await membershipService.GetMemberships();
            return Ok(memberships);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMembership(int campaignId, int characterId)
        {
            MembershipService membershipService = CreateMembershipService();
            var membership = await membershipService.GetMembershipById(campaignId, characterId);
            if (membership == null)
                return NotFound();
            return Ok(membership);
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMembership(int campaignId, int characterId)
        {
            MembershipService membershipService = CreateMembershipService();
            var membership = await membershipService.DeleteMembership(campaignId, characterId);
            if (membership == false)
                return NotFound();
            return Ok(membership);
        }
    }
}
