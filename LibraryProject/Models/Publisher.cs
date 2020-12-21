using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Įveskite leidyklos pavadinimą")]
        [Display(Name = "Pavadinimas")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Adresas")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "El. paštas")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
