using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class Campaign
    {
        [Key]
        public int CampaignID { get; set; } //Campaign ID number
        [Required]
        public string CampaignName { get; set; } //Name of the Campaign
        public string GameSystem { get; set; } // Name of the Game System being played (ie. 5e, 3.5, Pathfinder, Call of Cthullu)
        //[ForeignKey(nameof(DungeonMaster))] //Links DungeonMaster Player to the player GUID of the dungeon master
        public Guid DmGuid { get; set; }
        //public virtual Player DungeonMaster { get; set; }
        //public virtual List<Membership> = new List<Membership>(); //List of characters who are members of this campaign


    }
}
