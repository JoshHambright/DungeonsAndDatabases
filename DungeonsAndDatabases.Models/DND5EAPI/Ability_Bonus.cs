using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Ability_Bonus
    {
        public int bonus { get; set; }
        public APIReference ability_score { get; set; }
    }
}
