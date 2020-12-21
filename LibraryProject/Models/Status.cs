using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [Required]
        [Display(Name = "Stadija")]
        public string Name { get; set; }
    }
}
