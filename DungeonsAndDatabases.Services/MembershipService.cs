using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.MembershipModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.Services
{
    public class MembershipService
    {
        private readonly Guid _userId;

        public MembershipService(Guid userId)
        {
            _userId = userId;
        }

        //create membership
        public async Task<bool> CreateMembership(MembershipCreate model)
        {
            var entity =
                new Membership()
                {
                    CharacterId = model.CharacterID,
                    CampaignId = model.CampaignID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Memberships.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //view all memberships
        public async Task<IEnumerable<MembershipDetails>> GetMemberships()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await
                    ctx
                        .Memberships
                        .Select(
                            e =>
                                new MembershipDetails
                                {
                                    CampaignId = e.CampaignId,
                                    //Campaign = e.Campaign,
                                    CharacterId = e.CharacterId,
                                    //Character = e.Character
                                }
                        ).ToListAsync();
                return query;
            }
        }

        //view membership by key
        public async Task<MembershipDetails> GetMembershipById(int campaignId,int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Memberships
                    .Where(
                        x => x.CampaignId == campaignId && x.CharacterId == characterId)
                        .FirstOrDefaultAsync();
                var membershipDetail = new MembershipDetails
                {
                    CampaignId = entity.CampaignId,
                    CharacterId = entity.CharacterId,
                    //Campaign = entity.Campaign,
                    //)Character = entity.Character
                };
                return membershipDetail;
            }
        }

        //delete membership
        public async Task<bool> DeleteMembership(int campaignId, int characterId )
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Memberships
                    .Where(
                        x => x.CampaignId == campaignId && x.CharacterId == characterId)
                        .FirstOrDefaultAsync();
                ctx.Memberships.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }

        }
    }
}
