﻿using DungeonsAndDatabases.Data;
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
        //GUID
        private readonly Guid _userId;

        //DND5EAPI Stuff
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://www.dnd5eapi.co/api/";
        private readonly string _dnd5eAPI = "https://www.dnd5eapi.co";
        private readonly string _equipment = "equipment/";
        //private readonly string _magic_item = "magic-item/";

        public EquipmentService(Guid userId)
        {
            _userId = userId;
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

        public async Task<EquipmentDetails> GetEquipmentByEquipmentID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var equip = await ctx.Equipment.FindAsync();
                ctx
                    .Equipment
                    .Single(e => e.ID == ID);
                var result = new ApiEquipment();
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<ApiEquipment>();
                    if (result.Equipment_Category.name == "Weapon")
                    {
                        HttpResponseMessage weaponResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                        Weapon weapon = await weaponResponse.Content.ReadAsAsync<Weapon>();
                        //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
                        result = weapon;
                    }
                    if (result.Equipment_Category.name == "Armor")
                    {
                        HttpResponseMessage armorResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                        Armor armor = await armorResponse.Content.ReadAsAsync<Armor>();
                        //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
                        result = armor;
                    }
                    if (result.Equipment_Category.name == "Adventuring Gear")
                    {
                        HttpResponseMessage gearResponse = await _httpClient.GetAsync(_baseUrl + _equipment + equip.Name);
                        AdventureGear gear = await gearResponse.Content.ReadAsAsync<AdventureGear>();
                        //Equipment weapon = await response.Content.ReadAsAsync<Equipment>();
                        result = gear;
                    }
                }
                else
                {
                    result = null;

                }

                return
                new EquipmentDetails
                {
                    ID = equip.ID,
                    Notes = equip.Notes,
                    CharacterID = equip.CharacterID,
                    EquipmentType = equip.EquipmentType,
                    DND5EAPI_Info = result

                };
            }
        }




        public async Task<bool> UpdateEquipment(string equipment, EquipmentUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Equipment
                        .Where(e => e.Character.PlayerID == _userId).FirstOrDefaultAsync();
                entity.Name = model.Name;
                entity.Notes = model.Notes;
                entity.EquipmentType = model.EquipmentType;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteEquipment(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Equipment
                    .Where(e => e.CharacterID == id && e.Character.PlayerID == _userId).FirstOrDefaultAsync();

                ctx.Equipment.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }

        }

        public async Task<bool> CheckCharacterCredentials(int id)
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

        public async Task<bool> CheckEquipmentCredentials(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Equipment
                        .Where(e => e.ID == id).FirstOrDefaultAsync();
                if (entity.Character.PlayerID != _userId)
                    return false;
                return true;
            }
        }

    }
}
