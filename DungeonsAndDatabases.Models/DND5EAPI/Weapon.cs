using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Weapon : Equipment
    {
        public string weapon_category { get; set; }
        public string weapon_range { get; set; }
        public string category_range { get; set; }
        public Cost Cost { get; set; }
        public Damage damage { get; set; }
        public Range Range { get; set; }
        public int weight { get; set; }
        public APIReference Properties { get; set; }
        public string url { get; set; }
    }
}
