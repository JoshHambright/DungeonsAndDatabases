using DungeonsAndDatabases.Models.DiceModels;
using DungeonsAndDatabases.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{
    public class DiceController : ApiController
    {
        private DiceService CreateDiceService()
        {
            var diceService = new DiceService();
            return diceService;
        }

        [HttpGet]
        public IHttpActionResult RollMultipleDice([FromUri]int D, [FromUri]int N)
        {
            DiceService dice = CreateDiceService();
            var results = dice.GetMultipleDiceRoll(D,N);

            return Ok(results);
        }
        [HttpGet]
        public IHttpActionResult RollADie([FromUri] int D)
        {
            DiceService dice = CreateDiceService();
            var results = dice.GetDiceRoll(D);

            return Ok(results);
        }
    }
}
