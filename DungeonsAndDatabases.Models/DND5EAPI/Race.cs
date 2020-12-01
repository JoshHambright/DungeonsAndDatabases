using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Race
    {
        public string index { get; set; }
        public string name { get; set; }
        public int speed { get; set; }
        public List<Ability_Bonus> ability_bonuses { get; set; } = new List<Ability_Bonus>();
        public string alignment { get; set; }
        public string age { get; set; }
        public string size { get; set; }
        public string size_description { get; set; }
        public List<APIReference> starting_proficiencies { get; set; } = new List<APIReference>();
        public List<APIReference> languages { get; set; } = new List<APIReference>();
        public string language_desc { get; set; }
        public List<APIReference> Traits { get; set; } = new List<APIReference>();
        public List<APIReference> Subraces { get; set; } = new List<APIReference>();
        public string url { get; set; }

    }
}
