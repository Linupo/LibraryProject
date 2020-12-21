using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryProject.Models
{
    public class Computer
    {
        [DisplayName("ID")]
        public int ComputerId { get; set; }

        public int LibraryId { get; set; }

        [DisplayName("Procesorius")]
        [Required]
        public string CPU { get; set; }

        [DisplayName("Vaizdo plokštė")]
        [Required]
        public string GPU { get; set; }

        [DisplayName("Monitorius")]
        [Required]
        public string Monitor { get; set; }

        public virtual Library Library { get; set; }
    }
}
