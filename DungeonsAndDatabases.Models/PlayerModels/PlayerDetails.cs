using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.PlayerModels
{
    public class PlayerDetails
    {
        public Guid PlayerID { get; set; }
        public string PlayerName { get; set; }
    }
}
