using DungeonsAndDatabases.Data;
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
    public class EquipmentService
    {
        //Service for the Equipment objects accessed via the inventory Endpoint 

        //GUID
        private readonly Guid _userId;

        //DND5EAPI Stuff
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://www.dnd5eapi.co/api/";
        private readonly string _dnd5eAPI = "https://www.dnd5eapi.co";
        private readonly string _equipment = "equipment/";
        private readonly string _magicItem = "magic-items/";
        //private readonly string _magic_item = "magic-item/";

        public EquipmentService(Guid userId)
        {
            _userId = userId;
        }

        //Create Equipment
        public async Task<bool> CreateEquipment(EquipmentCreate model)
        {
            var entity = new Equipment()
            {
                Name = model.Name,
                Notes = model.Notes,
                CharacterID = model.CharacterID,
                EquipmentType = model.EquipmentType

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipment.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        //public async Task<Equipment> GetEquipment(string equipment)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _equipment + equipment);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Equipment result = await response.Content.ReadAsAsync<Equipment>();
        //        if (result.Equipment_Category.name == "Weapon")
        //        {
        //            HttpResponseMessage weaponResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equipment);
        //            Weapon weapon = await weaponResponse.Content.ReadAsAsync<Weapon>();
        //            //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
        //            return weapon;
        //        }
        //        if (result.Equipment_Category.name == "Armor")
        //        {
        //            HttpResponseMessage armorResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equipment);
        //            Armor armor = await armorResponse.Content.ReadAsAsync<Armor>();
        //            //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
        //            return armor;
        //        }
        //        if (result.Equipment_Category.name == "Adventuring Gear")
        //        {
        //            HttpResponseMessage gearResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equipment);
        //            AdventureGear gear = await gearResponse.Content.ReadAsAsync<AdventureGear>();
        //            //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
        //            return gear;
        //        }
        //        //if (result.Equipment_Category.name == "Wounderous Item")
        //        //{
        //        //    HttpResponseMessage gearResponse = await _httpClient.GetAsync(_baseUrl + _magic_item + equipment);
        //        //}

        //        return result;
        //    }
        //    return null;
        //}
        // Get the inventory of a character 
        public async Task<IEnumerable<EquipmentListView>> GetEquipmentByCharacterId(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Equipment
                        .Where(e => e.CharacterID == characterId)
                        .Select(
                            e =>
                                new EquipmentListView
                                {
                                    ID = e.ID,
                                    Name = e.Name,
                                    CharacterID = e.CharacterID,
                                    EquipmentType = e.EquipmentType
                                }
                        );
                return await query.ToListAsync();
            }
        }
        //Get the details on a specific Equipment object based on Equipment ID
        public async Task<EquipmentDetails> GetEquipmentByEquipmentID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var equip = await ctx.Equipment.FindAsync(ID);
                ctx
                    .Equipment
                    .Single(e => e.ID == ID);
                var result = new ApiEquipment();

                //Code below accesses the DND5EAPI and pulls data if available for the object
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<ApiEquipment>();
                    if (equip.EquipmentType == EquipmentType.MagicItem)
                    {
                        HttpResponseMessage magicItemResponse = await _httpClient.GetAsync(_baseUrl + _magicItem + equip.Name);
                        ApiMagicItem magicItem = await magicItemResponse.Content.ReadAsAsync<ApiMagicItem>();
                        result = magicItem;
                    }

                    if (result.Equipment_Category.name == "Weapon")
                    {
                        HttpResponseMessage weaponResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                        ApiWeapon weapon = await weaponResponse.Content.ReadAsAsync<ApiWeapon>();
                        //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
                        result = weapon;
                    }
                    if (result.Equipment_Category.name == "Armor")
                    {
                        HttpResponseMessage armorResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                        ApiArmor armor = await armorResponse.Content.ReadAsAsync<ApiArmor>();
                        //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
                        result = armor;
                    }
                    if (result.Equipment_Category.name == "Adventuring Gear")
                    {
                        HttpResponseMessage gearResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                        ApiAdventureGear gear = await gearResponse.Content.ReadAsAsync<ApiAdventureGear>();
                        //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
                        result = gear;
                    }
                }
                //Code to pull details for magic items
                response = await _httpClient.GetAsync(_baseUrl + _magicItem + equip.Name);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<ApiEquipment>();
                    if (equip.EquipmentType == EquipmentType.MagicItem)
                    {
                        HttpResponseMessage magicItemResponse = await _httpClient.GetAsync(_baseUrl + _magicItem + equip.Name);
                        ApiMagicItem magicItem = await magicItemResponse.Content.ReadAsAsync<ApiMagicItem>();
                        result = magicItem;
                    }
                }
                else
                {
                    result = null;

                }

                return
                new EquipmentDetails
                {
                    Name = equip.Name,
                    ID = equip.ID,
                    Notes = equip.Notes,
                    CharacterID = equip.CharacterID,
                    EquipmentType = equip.EquipmentType,
                    DND5EAPI_Info = result

                };
            }
        }



        //Update an equipment item in a characters inventory
        public async Task<bool> UpdateEquipment(int id, EquipmentUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Equipment
                        .Where(e => e.ID == id).FirstOrDefaultAsync();
                entity.Name = model.Name;
                entity.Notes = model.Notes;
                entity.EquipmentType = model.EquipmentType;

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //Delete an equipment item from a characters inventory
        public async Task<bool> DeleteEquipment(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Equipment
                    .Where(e => e.ID == id).FirstOrDefaultAsync();

                ctx.Equipment.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }

        }
        //Check credentials to make sure you own a character before editing the inventory
        public async Task<bool> CheckCharacterCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Characters
                        .Where(e => e.CharacterID == id).FirstOrDefaultAsync();
                if (entity == null || entity.PlayerID != _userId)
                    return false;
                return true;
            }
        }
        //Check the credentials on an equipment object before doing update or delete
        public async Task<bool> CheckEquipmentCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Equipment
                        .Where(e => e.ID == id).FirstOrDefaultAsync();
                if (entity == null || entity.Character.PlayerID != _userId)
                    return false;
                return true;
            }
        }

    }
}
