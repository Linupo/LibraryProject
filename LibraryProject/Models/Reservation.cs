using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Pradžia")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Pabaiga")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }

        public virtual List<Book> Books { get; set; }

        public virtual List<Book> Computers { get; set; }
    }
}
