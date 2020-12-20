using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "Vardas")]
        [Required(ErrorMessage = "Įveskite savo vardą")]
        public string FirstName { get; set; }

        [Display(Name = "Pavardė")]
        [Required(ErrorMessage = "Įveskite savo pavardę")]
        public string LastName { get; set; }

        [Display(Name = "Asmens kodas")]
        [Required(ErrorMessage = "Įveskite savo asmens kodą")]
        public string PersonalCode { get; set; }

        [Display(Name = "El. pašto adresas")]
        [Required(ErrorMessage = "Įveskite savo el. pašto adresą")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Slaptažodis")]
        [Required(ErrorMessage = "Įveskite slaptažodį")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Gimimo data")]
        [Required(ErrorMessage = "Nurodykite savo gimimo datą")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}