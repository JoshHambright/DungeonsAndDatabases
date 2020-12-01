using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class ability_scores
    {
        public string index { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public List<string> desc { get; set; } = new List<string>();
        public List<APIReference> skills { get; set; } = new List<APIReference>();
        public string url { get; set; }
    }
}
