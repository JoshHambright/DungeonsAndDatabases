using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.Loot;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class CampaignLootService
    {
        //GUID
        private readonly Guid _userId;

        public CampaignLootService(Guid userId)
        {
            _userId = userId;
        }

        //Create New Loot Item
        public async Task<bool> CreateCampaignLoot(LootCreate model)
        {
            var entity =
                new Loot()
                {
                    Name = model.Name,
                    Description = model.Description,
                    ValueInGP = model.ValueInGP,
                    CampaignID = model.CampaignID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CampaignLoot.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Get All Loot items a DM has
        public async Task<IEnumerable<LootListItem>> GetAllCampaignLoot()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .CampaignLoot
                        .Where(e => e.Campaign.DmGuid == _userId)
                        .Select(
                            x =>
                                new LootListItem
                                {
                                    LootID = x.LootID,
                                    Name = x.Name,
                                    CampaignID = x.CampaignID,
                                    CampaignName = x.Campaign.CampaignName
                                }
                            ).ToListAsync();
                return query;
            }
        }

        //Get Details on a Loot Item
        public async Task<LootDetailsWithCampaign> GetCampaignLootByID(int lootId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .CampaignLoot
                        .Where(e => e.Campaign.DmGuid == _userId && e.LootID == lootId)
                        .FirstOrDefaultAsync();
                var lootDetail =
                     new LootDetailsWithCampaign
                     {
                         LootID = query.LootID,
                         Name = query.Name,
                         Description = query.Description,
                         ValueInGP = query.ValueInGP,
                         CampaignID = query.CampaignID,
                         CampaignName = query.Campaign.CampaignName,
                         DMName = query.Campaign.DungeonMaster.PlayerName
                     };
                return lootDetail; 
            }
        }

        //Update Loot Item
        public async Task<bool> UpdateCampaignLoot(int lootId,LootUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.CampaignLoot
                    .Where(e => e.LootID == lootId).FirstOrDefaultAsync();
                entity.Name = model.Name;
                entity.ValueInGP = model.ValueInGP;
                entity.Description = model.Description;
                return await ctx.SaveChangesAsync() == 1;
            }

        }
        
        //Delete Loot Item
        public async Task<bool> DeleteCampaignLoot(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.CampaignLoot
                    .Where(e => e.LootID == id).FirstOrDefaultAsync();
                ctx.CampaignLoot.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //Check to see if the user is the DM of a campaign
        public async Task<bool> CheckDMCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.CampaignLoot
                    .Where(e => e.LootID == id).FirstOrDefaultAsync();
                if (entity == null || entity.Campaign.DmGuid != _userId)
                    return false;
                return true;
            }
        }
        //Check to see if a user is the DM of a campaign
        public async Task<bool> CheckCreateCredentials(int campaignId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Campaigns
                    .Where(e => e.CampaignID == campaignId).FirstOrDefaultAsync();
                if (entity == null || entity.DmGuid != _userId)
                    return false;
                return true;
            }
        }


    }
}
