using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DiceModels
{
    //Model for returning multiple dice rolls
    public class DiceResults
    {
        public List<DiceSingle> Rolls { get; set; } = new List<DiceSingle>();
        public int Total { get
            {
                int total = 0;
                foreach (var roll in Rolls)
                    total += roll.Result;
                return total;
            } 
        }
        public int Advantage { get
            {
                int highest = Rolls.Max(roll => roll.Result);
                return highest;
            } 
        }
        public int Disadvantage { get
            {
                int lowest = Rolls.Min(roll => roll.Result);
                return lowest;
            } 
        }
    }
}
