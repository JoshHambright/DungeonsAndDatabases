using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class CharacterService
    {
        //GUID
        private readonly Guid _userId;

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
                Level = model.Level
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
                        .Select(
                            e =>
                                new CharacterListItem
                                {
                                    CharacterName = e.CharacterName,
                                    Level = e.Level
                                }
                        );
                return await query.ToArrayAsync();
            }
        }

        //Get Character by ID
        public async Task<CharacterDetail> GetCharacter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var cat = await ctx.Characters.FindAsync(id);
                    ctx
                        .Characters
                        .Single(c => c.CharacterID == id);
                return
                    new CharacterDetail
                    {
                        //PlayerID = cat.PlayerID,
                        CharacterName = cat.CharacterName,
                        Race = cat.Race,
                        Class = cat.Class,
                        Level = cat.Level
                    };
            }
        }
        //Update A Character
        public async Task<bool> UpdateCharacter(int id, CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterID == id);
                entity.CharacterName = model.CharacterName;
                entity.Race = model.Race;
                entity.Class = model.Class;
                entity.Level = model.Level;


                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //Delete a character
        public async Task<bool> DeleteCharacter(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterID == id);
                ctx.Characters.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
