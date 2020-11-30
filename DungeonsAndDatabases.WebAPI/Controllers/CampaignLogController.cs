using DungeonsAndDatabases.Models.LogModels;
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
    public class CampaignLogController : ApiController
    {
        //Establish DB Connection
        private CampaignLogService CreateCampaignLogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var campaignLogService = new CampaignLogService(userId);
            return campaignLogService;
        }

        //Create
        /// <summary>
        /// Create a new Campaign Log Entry
        /// </summary>
        /// <param name="logEntry"></param>
        /// <returns>Creates a campaign log entry assigned to the current player.  Verifies you are a member or DM of the campaign</returns>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> CreateCampaignLogEntry(LogEntryCreate logEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignLogService();
            var credentials = await service.CheckMembershipandDMCredentials(logEntry.CampaignID);
            if (credentials == false)
                return Unauthorized();
            var result = await service.CreateCampaignLogAsync(logEntry);

            if (result == false)
                return InternalServerError();
            return Ok();
        }

        //Read
        /// <summary>
        /// Get all Campaign Logs for currently logged in player
        /// </summary>
        /// <returns>Returns a list of campaign logs user created</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetCampaignLogs()
        {
            CampaignLogService campaignLogService = CreateCampaignLogService();
            var campaignLogs = await campaignLogService.GetAllLogsAsync();
            return Ok(campaignLogs);
        }

        //Read By ID
        /// <summary>
        /// Get details on a specific campaign log
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All the campaign log details for a specified campaign log</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetCharacter(int id)
        {
            CampaignLogService campaignLogService = CreateCampaignLogService();
            var credentials = await campaignLogService.CheckPlayerCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var campaignLog = await campaignLogService.GetLogByIDAsync(id);
            if (campaignLog == null)
                return NotFound();
            return Ok(campaignLog);
        }

        //Update Campaign Log
        /// <summary>
        /// Update Specific campaign log
        /// </summary>
        /// <param name="id"></param>
        /// <param name="logEntry"></param>
        /// <returns>Updates a campaign log entry</returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCampaignLog([FromUri] int id, [FromBody] LogEntryUpdate logEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCampaignLogService();
            var credentials = await service.CheckPlayerCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.UpdateCampaignLogAsync(id, logEntry);
            if (result == false)
                return InternalServerError();
            return Ok();
        }

        //Delete a Campaign Log
        /// <summary>
        /// Delete a specific campaign log entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes a specified campaign log</returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCampaignLogEntry(int id)
        {
            var service = CreateCampaignLogService();
            var credentials = await service.CheckPlayerCredentials(id);
            if (credentials == false)
                return Unauthorized();
            var result = await service.DeleteCampaignLogEntryAsync(id);
            if (result == false)
                return InternalServerError();
            return Ok();
        }
    }
}
