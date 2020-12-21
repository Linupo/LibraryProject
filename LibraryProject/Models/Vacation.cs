using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Vacation
    {
        public int VacationId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Pradžios data")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Pabaigos data")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsAccepted { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
