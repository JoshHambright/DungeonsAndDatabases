using DungeonsAndDatabases.Models.DND5EAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class DND5eAPI_TestService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://www.dnd5eapi.co/api/";
        private readonly string _dnd5eAPI = "https://www.dnd5eapi.co";
        private readonly string _classes = "classes/";
        private readonly string _races = "races/";
        private readonly string _equipment = "equipment/";
        private readonly string _magic_item = "magic-item/";
        //    public async Task<Race> GetRaceFromAPIAsync(string race)
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _races + race);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Race result = await response.Content.ReadAsAsync<Race>();
        //            return result;
        //        }
        //        return null;
        //    }
        //    public async Task<Race_Short> GetShortRaceFromAPIAsync(string race)
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _races + race);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Race_Short result = await response.Content.ReadAsAsync<Race_Short>();
        //            return result;
        //        }
        //        return null;
        //    }

        //    public async Task<Classes_Short> GetShortClassFromAPIAsync(string classes)
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _classes + classes);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Classes_Short result = await response.Content.ReadAsAsync<Classes_Short>();
        //            return result;
        //        }
        //        return null;
        //    }
        //public async Task<ApiEquipment> GetEquipmentFromAPIAsync(string equipment)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _equipment + equipment);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        ApiEquipment result = await response.Content.ReadAsAsync<ApiEquipment>();
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


    }
}
