using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Loot
{
    public class LootUpdate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        public double ValueInGP { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(2000, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }
    }
}
