using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Vardas")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Asmens kodas")]
        public string PersonalCode { get; set; }

        [Required]
        [Display(Name = "El. paštas")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string IsActive { get; set; }

        [Required]
        [Display(Name = "Gimimo data")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
