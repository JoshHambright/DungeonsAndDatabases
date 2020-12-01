using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.CharacterModels;
using DungeonsAndDatabases.Models.DND5EAPI;
using DungeonsAndDatabases.Models.EquipmentModels;
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
        private readonly string _dnd5eAPI = "https://www.dnd5eapi.co";
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
                HttpResponseMessage race_response = await _httpClient
                    .GetAsync(_baseUrl + _races + cat.Race);
                var dnd5eRace = new Race_Short();
                if (race_response.IsSuccessStatusCode)
                {
                    Race_Short result = await race_response.Content
                        .ReadAsAsync<Race_Short>();
                    dnd5eRace = result;
                    dnd5eRace.url = _dnd5eAPI + dnd5eRace.url;
                }
                else
                {
                    dnd5eRace = null;
                }
                var dnd5eClass = new Classes_Short();
                HttpResponseMessage class_response = await _httpClient
                    .GetAsync(_baseUrl + _classes + cat.Class);
                if (class_response.IsSuccessStatusCode)
                {
                    Classes_Short result = await class_response.Content
                        .ReadAsAsync<Classes_Short>();
                    dnd5eClass = result;
                    dnd5eClass.url = _dnd5eAPI + dnd5eClass.url;
                    dnd5eClass.starting_equipment = _dnd5eAPI + dnd5eClass.starting_equipment;
                    dnd5eClass.class_levels = _dnd5eAPI + dnd5eClass.class_levels;
                }
                else
                {
                    dnd5eClass = null;
                }


                return
                    new CharacterDetail
                    {
                        PlayerID = cat.PlayerID,
                        CharacterName = cat.CharacterName,
                        Race = cat.Race,
                        Class = cat.Class,
                        Level = cat.Level,
                        Race_Details = dnd5eRace,
                        Class_Details = dnd5eClass,
                        Inventory = cat.Inventory.Select(
                            x =>
                                new EquipmentListView
                                {
                                    ID = x.ID,
                                    Name= x.Name,
                                    CharacterID = x.CharacterID,
                                    EquipmentType = x.EquipmentType
                                }
                            ).ToList()

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
