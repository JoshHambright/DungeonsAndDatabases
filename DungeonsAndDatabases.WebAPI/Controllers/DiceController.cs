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
        //Roll Multiple dice
        /// <summary>
        /// Roll Multiple Dice
        /// </summary>
        /// <param name="D"></param>
        /// <param name="N"></param>
        /// <returns>Roll multiple dice and return the results</returns>
        [HttpGet]
        public IHttpActionResult RollMultipleDice([FromUri]int D, [FromUri]int N)
        {
            DiceService dice = CreateDiceService();
            var results = dice.GetMultipleDiceRoll(D,N);

            return Ok(results);
        }
        //Roll a single Die
        /// <summary>
        /// Roll a die
        /// </summary>
        /// <param name="D"></param>
        /// <returns>Rolls a die and returns the result</returns>
        [HttpGet]
        public IHttpActionResult RollADie([FromUri] int D)
        {
            DiceService dice = CreateDiceService();
            var results = dice.GetDiceRoll(D);

            return Ok(results);
        }
    }
}
