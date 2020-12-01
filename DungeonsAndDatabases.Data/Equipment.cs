using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class Equipment
    {
        [Key]
        public string Name { get; set; } 
        public string Index { get; set; }
        public int Weight { get; set; }
        public double Cost { get; set; }
        public string Desc { get; set; }
    }
}
