using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CharacterModels
{
    public class CharacterEdit
    {
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string CharacterName { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Race { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Class { get; set; }
        [MinLength(1, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(3, ErrorMessage = "There are too many characters in this field.")]
        public string Level { get; set; }

        //public List<string> Inventory;
    }
}
