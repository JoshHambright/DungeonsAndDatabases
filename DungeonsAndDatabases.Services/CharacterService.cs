using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.CharacterModels;
using DungeonsAndDatabases.Models.DND5EAPI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class CharacterService
    {
        //GUID
        private readonly Guid _userId;

        //DND5EAPI Stuff
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://www.dnd5eapi.co/api/";
        private readonly string _classes = "classes/";
        private readonly string _races = "races/";

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        //Create
        //Creates a character
        public async Task<bool> CreateCharacter(CharacterCreate model)
        {
            var entity = new Character()
            {
                CharacterName = model.CharacterName,
                Race = model.Race,
                Class = model.Class,
                Level = model.Level,
                PlayerID = _userId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
                
            }
        }

        //Read 
        //Get All Characters
        //public async Task<IEnumerable<CharacterListItem>> GetCharacter()
        public async Task<IEnumerable<CharacterListItem>> GetCharacter()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                        .Characters
                        .Where(e => e.PlayerID == _userId)
                        .Select(                    
                            e =>
                                new CharacterListItem
                                {
                                    CharacterId = e.CharacterID,
                                    CharacterName = e.CharacterName,
                                    Level = e.Level,
                                    PlayerID = e.PlayerID
                                }
                        );
                return await query.ToArrayAsync();
            }
        }

        //Get Character by CharacterID
        public async Task<CharacterDetail> GetCharacter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var cat = await ctx.Characters.FindAsync(id);
                    ctx
                        .Characters
                        .Single(c => c.CharacterID == id);
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _races + cat.Race);
                var dnd5eRace = new Race_Short();
                if (response.IsSuccessStatusCode)
                {
                    Race_Short result = await response.Content.ReadAsAsync<Race_Short>();
                    dnd5eRace = result;
                    dnd5eRace.url = "https://www.dnd5eapi.co/" + dnd5eRace.url;
                }
                else
                {
                    dnd5eRace = null;
                }
                return
                    new CharacterDetail
                    {
                        PlayerID = cat.PlayerID,
                        CharacterName = cat.CharacterName,
                        Race = cat.Race,
                        Class = cat.Class,
                        Level = cat.Level,
                        Race_Details = dnd5eRace

                    };
            }
        }
        //Update A Character
        public async Task<bool> UpdateCharacter(int id, CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Characters
                        .Where(e => e.CharacterID == id).FirstOrDefaultAsync();
                //if (entity.PlayerID != _userId)
                //    return false;
                //ctx
                    //    .Characters
                    //    .Single(e => e.CharacterID == id);
                entity.CharacterName = model.CharacterName;
                entity.Race = model.Race;
                entity.Class = model.Class;
                entity.Level = model.Level;
                
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //Delete a character by Character ID
        public async Task<bool> DeleteCharacter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Characters
                    .Where(e => e.CharacterID == id && e.PlayerID == _userId).FirstOrDefaultAsync();
                    
                    //ctx
                    //    .Characters
                    //    .Single(e => e.CharacterID == id);
                ctx.Characters.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> CheckCharCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Characters
                        .Where(e => e.CharacterID == id).FirstOrDefaultAsync();
                if (entity.PlayerID != _userId)
                    return false;
                return true;
            }
        }
    }

}
