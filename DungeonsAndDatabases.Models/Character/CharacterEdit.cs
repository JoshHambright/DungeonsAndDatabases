using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Character
{
    public class CharacterEdit
    {
        public string CharacterName { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Level { get; set; }

        //public List<string> Inventory;
    }
}
