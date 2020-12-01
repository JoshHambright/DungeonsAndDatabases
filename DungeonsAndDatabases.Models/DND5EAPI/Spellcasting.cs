using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Spellcasting
    {
        public int level { get; set; }
        public APIReference spellcasting_ability { get; set; }
        public List<string> info { get; set; } = new List<string>();
    }
}
