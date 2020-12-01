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
        private readonly string _classes = "classes/";
        private readonly string _races = "races/";

        public async Task<Race> GetRaceFromAPIAsync(string race)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _races + race);
            if (response.IsSuccessStatusCode)
            {
                Race result = await response.Content.ReadAsAsync<Race>();
                return result;
            }
            return null;
        }
    }
}
