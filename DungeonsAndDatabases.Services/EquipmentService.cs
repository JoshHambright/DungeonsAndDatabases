using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class EquipmentService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = "https://www.dnd5eapi.co/api/";

        public async Task<Equipment> GetEquipmentCategoriesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + "equipment-categories/");
            if(response.IsSuccessStatusCode)
            {
                Equipment equipment = await response.Content.ReadAsAsync<Equipment>();
                return equipment;
            }
            return null;
        }
    }
}
