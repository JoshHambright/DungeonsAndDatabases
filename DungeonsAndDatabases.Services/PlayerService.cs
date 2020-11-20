using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.Services
{
    public class PlayerService
    {   //Guid
        private readonly Guid _playerId;

        public PlayerService(Guid playerId)
        {
            _playerId = playerId;
        }
        //Create
        public async Task<bool> CreatePlayer(PlayerCreate model)
        {
            var entity = new Player()
            {
                PlayerName = model.PlayerName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //Read
        public async Task<IEnumerable<PlayerListItem>> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Players
                        .Select(
                            e =>
                                new PlayerListItem
                                {
                                    PlayerName = e.PlayerName
                                }
                        );
                await query.ToListAsync();
                return query;
            }
        }
        public async Task<PlayerDetails> GetPlayerById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Players.FindAsync(id);
                ctx
                    .Players
                    .Single(e => e.PlayerID == id);
                return
                    new PlayerDetails
                    {
                        PlayerName = entity.PlayerName,
                        PlayerID = entity.PlayerID
                    };
            }
        }
        //Update
        public async Task<bool> UpdatePlayer(string name, PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Players
                        .Single(e => e.PlayerName == name);
                entity.PlayerName = model.PlayerName;
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //Delete
        public async Task<bool> DeletePlayer(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Players
                    .Single(e => e.PlayerName == name);
                ctx.Players.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
