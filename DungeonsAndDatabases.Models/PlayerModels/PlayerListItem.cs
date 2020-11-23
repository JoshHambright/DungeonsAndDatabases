using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.PlayerModels
{
    public class PlayerListItem
    {
        public Guid PlayerID { get; set; }
        public string PlayerName { get; set; }
    }
}
