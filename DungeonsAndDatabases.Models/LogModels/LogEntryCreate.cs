using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.LogModels
{
    public class LogEntryCreate
    {

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(5000, ErrorMessage = "There are too many characters in this field. Limit entries to 5000 characters")]
        public string Message { get; set; }
        [Required]
        public int CampaignID {get; set;}
        
    }
}
