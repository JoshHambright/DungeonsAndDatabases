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
        public IHttpActionResult RollDice(int D)
        {
            DiceService dice = CreateDiceService();
            var diceRoll = dice.GetDiceRoll(D);

            return Ok(diceRoll);
        }
    }
}
