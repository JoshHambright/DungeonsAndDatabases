using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Classes_Short
    {
        public string index { get; set; }
        public string name { get; set; }
        public int hit_die { get; set; }
        public List<Ability_Scores> saving_throws { get; set; } = new List<Ability_Scores>();
        public string starting_equipment { get; set; }
        public string class_levels { get; set; }
        public Spellcasting Spellcasting { get; set; }
        public string spells { get; set; }
        public string url { get; set; }
    }
}
