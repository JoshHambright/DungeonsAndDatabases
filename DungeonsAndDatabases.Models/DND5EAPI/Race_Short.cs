using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Race_Short
    {
        public string index { get; set; }
        public string name { get; set; }
        public List<Ability_Bonus> ability_bonuses { get; set; } = new List<Ability_Bonus>();
        public string alignment { get; set; }
        public string age { get; set; }
        public string size { get; set; }
        public string size_description { get; set; }
        public string url { get; set; }
    }
}
