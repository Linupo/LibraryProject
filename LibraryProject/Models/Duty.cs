using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Duty
    {
        public int DutyId { get; set; }

        [Required]
        [Display(Name = "Pareigos")]
        public string Name { get; set; }
    }
}
