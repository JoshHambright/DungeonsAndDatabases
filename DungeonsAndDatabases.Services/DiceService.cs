using DungeonsAndDatabases.Models.DiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class DiceService
    {
        private static readonly RNGCryptoServiceProvider _randy = new RNGCryptoServiceProvider();
        
        //Rolls a single die with the specified number of sides
        //Return the result (int)
        public DiceSingle GetDiceRoll(int dicesides)
        {
            var roll = new DiceSingle();
            roll.DieType = $"D{dicesides}"
            int diceRoll = 0;
            while (diceRoll < 1)
            {

                byte[] randy = new byte[1];

                _randy.GetBytes(randy);

                double asciiValueOfRandomCharacter = Convert.ToDouble(randy[0]);

                double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

                double randomRoll = Math.Floor(multiplier * (dicesides + 1));
                diceRoll = Convert.ToInt32(randomRoll);
            }
            roll.Result = diceRoll;
            return roll;
        }

        //Rolls n number of dice with a specified number of sides.
        //Returns a DiceResult Object (list of dice rolls, total for all the
        //rolls, the highest (for rolling advantage) and the lowest
        //(for rolling disadvantage)
        
        public DiceResults GetMultipleDiceRoll(int dicesides, int n)
        {
            var rolls = new DiceResults();
            int looper = 0;
            while (looper != n)
            {
                var roll = new DiceSingle();
                int diceRoll = 0;
                roll.DieType = $"D{dicesides}";
                while (diceRoll < 1)
                {

                    byte[] randy = new byte[1];

                    _randy.GetBytes(randy);

                    double asciiValueOfRandomCharacter = Convert.ToDouble(randy[0]);

                    double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

                    double randomRoll = Math.Floor(multiplier * (dicesides + 1));
                    diceRoll = Convert.ToInt32(randomRoll);
                }
                roll.Result = diceRoll;
                rolls.Rolls.Add(roll);
                looper++;
            }
            return rolls;
        }


    }
}
