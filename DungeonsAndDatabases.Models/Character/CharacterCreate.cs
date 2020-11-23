using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Character
{
    public class CharacterCreate
    {
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Level { get; set; }
    }
}
