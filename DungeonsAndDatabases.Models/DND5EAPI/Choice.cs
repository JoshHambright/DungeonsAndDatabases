using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Choice
    {
        public int choose { get; set; }
        public string type { get; set; }
        public List<APIReference> from { get; set; } = new List<APIReference>();
    }
}
