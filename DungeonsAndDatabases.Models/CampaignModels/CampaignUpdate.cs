using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CampaignModels
{
    public class CampaignUpdate
    {
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string CampaignName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string GameSystem { get; set; }
        public Guid DmGuid { get; set; }
    }
}
