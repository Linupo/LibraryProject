using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        
        //public int StatusId { get; set; }

        //public int LibraryId { get; set; }

        //public int PublisherId { get; set; }

        //public int BookId { get; set; }

        [Required]
        [Display(Name = "Kaina")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Įveskite kainą")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Kiekis")]
        [Range(1, int.MaxValue, ErrorMessage = "Įveskite kiekį")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Pradžios data")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Pabaigos data")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public virtual Status Status { get; set; }

        [Required]
        public virtual Library Library { get; set; }

        [Required]
        public virtual Publisher Publisher { get; set; }

        [Required]
        public virtual Book Book { get; set; }
    }
}
