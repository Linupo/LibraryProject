using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }

        [Required]
        public int LibraryId { get; set; }

        [Required]
        public string CPU { get; set; }

        [Required]
        public string GPU { get; set; }

        [Required]
        public string Monitor { get; set; }

        public virtual Library Library { get; set; }
    }
}
