using DungeonsAndDatabases.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{
    public class DND5EAPI_TestController : ApiController
    {
        private DND5eAPI_TestService CreateDND5eAPIService()
        {
            var service = new DND5eAPI_TestService();
            return service;
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> GetShortRaceInfoAsync(string race)
        //{
        //    DND5eAPI_TestService service = CreateDND5eAPIService();
        //    var result = await service.GetShortRaceFromAPIAsync(race);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IHttpActionResult> GetRaceInfoAsync(string racefull)
        //{
        //    DND5eAPI_TestService service = CreateDND5eAPIService();
        //    var result = await service.GetRaceFromAPIAsync(racefull);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IHttpActionResult> GetClassInfoAsync(string classes)
        //{
        //    DND5eAPI_TestService service = CreateDND5eAPIService();
        //    var result = await service.GetShortClassFromAPIAsync(classes);
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IHttpActionResult> GetEquipmentAsync(string equipment)
        {
            DND5eAPI_TestService service = CreateDND5eAPIService();
            var result = await service.GetEquipmentFromAPIAsync(equipment);
            return Ok(result);
        }


    }
}
