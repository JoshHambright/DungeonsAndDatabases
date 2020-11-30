using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CharacterModels
{
    public class CharacterCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string CharacterName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Race { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Class { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(3, ErrorMessage = "There are too many characters in this field.")]
        public string Level { get; set; }
        [ForeignKey(nameof(Player))] //Foreign key that will be used to assign character to its player
        public Guid PlayerID { get; set; }
    }
}
