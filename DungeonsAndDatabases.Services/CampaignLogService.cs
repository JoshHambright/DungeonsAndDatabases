using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.LogModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class CampaignLogService
    {
        private readonly Guid _userId;

        public CampaignLogService(Guid playerId)
        {
            _userId = playerId;
        }

        //Create
        public async Task<bool> CreateCampaignLogAsync(LogEntryCreate model)
        {
            var entity = new LogEntry()
            {
                Message = model.Message,
                DateCreated = DateTimeOffset.Now,
                CampaignID = model.CampaignID,
                PlayerID = _userId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CampaignLogs.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        // Read
        // Returns all of the Campaign Logs you've created
        public async Task<IEnumerable<LogEntryListItem>> GetAllLogsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                    .CampaignLogs
                    .Where(e => e.PlayerID == _userId)
                    .Select(
                        e =>
                            new LogEntryListItem
                            {
                                LogID = e.LogID,
                                DateCreated = e.DateCreated,
                                DateUpdated = e.DateUpdated,
                                CampaignID = e.CampaignID,
                                CampaignName = e.Campaign.CampaignName
                            }
                        ).ToListAsync();
                return entity;
            }
        }

        //Read 
        //Returns a specific Campaign Log with full details

        public async Task<LogEntryDetails> GetLogByIDAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx
                    .CampaignLogs
                    .Where(e => e.LogID == id).FirstOrDefaultAsync();
                string name = "";
                if (entity.Campaign.DmGuid == _userId)
                    name = "Dungeon Master";
                else
                    name = entity.Campaign.Memberships
                                            .Where(e => e.Character.PlayerID == _userId)
                                            .FirstOrDefault()
                                            .Character.CharacterName;

                return
                    new LogEntryDetails
                    {
                        LogID = entity.LogID,
                        Message = entity.Message,
                        CampaignID = entity.CampaignID,
                        CampaingName = entity.Campaign.CampaignName,
                        CharacterName = name,
                        PlayerID = entity.PlayerID,
                        PlayerName = entity.Player.PlayerName,
                        DateCreated = entity.DateCreated,
                        DateUpdated = entity.DateUpdated
                    };
            }
        }
        //Update a camapign log
        public async Task<bool> UpdateCampaignLogAsync(int id, LogEntryUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.CampaignLogs
                    .Where(e => e.LogID == id).FirstOrDefaultAsync();
                entity.Message = model.Message;
                entity.DateUpdated = DateTimeOffset.Now;
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Delete a campaign
        public async Task<bool> DeleteCampaignLogEntryAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.CampaignLogs
                    .Where(e => e.LogID == id).FirstOrDefaultAsync();
                ctx.CampaignLogs.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        // Check the Credentials of the DM of a campaign
        public async Task<bool> CheckMembershipandDMCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Campaigns
                    .Where(e => e.CampaignID == id).FirstOrDefaultAsync();
                if (entity == null || entity.DmGuid != _userId || entity.Memberships.Any(x => x.Character.PlayerID != _userId))
                {
                    return false;
                }
                return true;
            }
        }

        //Check the credentials to see if user owns a player

        public async Task<bool> CheckPlayerCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.CampaignLogs
                    .Where(e => e.LogID == id).FirstOrDefaultAsync();
                if (entity == null || entity.PlayerID != _userId)
                    return false;
                return true;
            }
        }
    }
}
