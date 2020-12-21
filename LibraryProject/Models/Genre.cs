using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Žanras")]
        public string Name { get; set; }
    }
}
