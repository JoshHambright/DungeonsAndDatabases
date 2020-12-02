using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class ApiMagicItem : ApiEquipment
    {
        public List<string> desc { get; set; } = new List<string>();
    }
}
