using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{   
    public class EquipmentController : ApiController
    {
        //private readonly HttpClient _httpClient = new HttpClient();
        //private readonly string baseUrl = "https://www.dnd5eapi.co/api/";
        //public async Task<IHttpActionResult> GetEquipmentAysnc(string name)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + "equipment-categories/");
        //       if(response.IsSuccessStatusCode)
        //    {
        //        Equipment equipment = await response.Content.ReadAsAsync<Equipment>();
        //        return (IHttpActionResult)equipment;
        //    }
        //    return null;
        //}
    }
}
