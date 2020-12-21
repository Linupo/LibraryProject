using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Condition
    {
        public int ConditionId { get; set; }

        [Required]
        [Display(Name = "Būklė")]
        public string Name { get; set; }
    }
}
