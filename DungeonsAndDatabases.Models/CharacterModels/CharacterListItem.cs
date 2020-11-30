using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CharacterModels
{
    public class CharacterListItem
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string Level { get; set; }
        public Guid PlayerID { get; set; }
    }
}
