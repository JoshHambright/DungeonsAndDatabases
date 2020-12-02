using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class ApiWeapon : ApiEquipment
    {
        public string weapon_category { get; set; }
        public string weapon_range { get; set; }
        public string category_range { get; set; }
        public Cost Cost { get; set; }
        public Damage damage { get; set; }
        public Range Range { get; set; }
        public int weight { get; set; }
        public List<APIReference> Properties { get; set; } = new List<APIReference>();
        public string url { get; set; }
    }
}
