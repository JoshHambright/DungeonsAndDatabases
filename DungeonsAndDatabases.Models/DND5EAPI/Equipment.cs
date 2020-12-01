using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Equipment
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public APIReference Equipment_Category { get; set; }
    }
}
