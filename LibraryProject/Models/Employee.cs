using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int? ReportsToId { get; set; }

        //[Required]
        //public int DutyId { get; set; }

        //[Required]
        //public int LibraryId { get; set; }

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
        [Display(Name = "Alga")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Įveskite darbuotojo algą")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "El. paštas")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ForeignKey("ReportsToId")]
        public virtual Employee ReportsTo { get; set; }

        public virtual Duty Duty { get; set; }

        public virtual Library Library { get; set; }
    }
}
