using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentUpdate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(3000, ErrorMessage = "There are too many characters in this field.")]
        public string Notes { get; set; }
        [Required]
        public EquipmentType EquipmentType { get; set; }
    }
}
