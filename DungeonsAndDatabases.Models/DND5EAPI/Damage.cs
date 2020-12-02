using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Damage
    {
        public string damage_dice { get; set; }
        public APIReference damage_type { get; set; }
    }
}
