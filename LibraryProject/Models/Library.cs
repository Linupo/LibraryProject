using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryProject.Models
{
    public class Library
    {
        public int LibraryId { get; set; }

        [Required]
        [DisplayName("Biblioteka")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public TimeSpan OpenFrom { get; set; }

        [Required]
        public TimeSpan OpenUntil { get; set; }
    }
}
