using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class Player
    {
        [Key]
        public Guid PlayerID { get; set; } = Guid.NewGuid();
        [Required]
        public string PlayerName { get; set; }


        public virtual List<Character> Characters { get; set; } = new List<Character>();
        public virtual List<Campaign> Campaigns { get; set; } = new List<Campaign>();
       // public virtual List<MembershipDetails> CharacterCampaign { get; set; } = new List<MembershipDetails>();
    }
}
