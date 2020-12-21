using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Vardas")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Autorius")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
