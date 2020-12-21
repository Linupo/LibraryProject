using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Book
    {
        public int BookId { get; set; }

        //public int? LibraryId { get; set; }

        //public int? PublisherId { get; set; }

        //public int AuthorId { get; set; }

        //public int GenreId { get; set; }

        //public int ConditionId { get; set; }

        [Required(ErrorMessage = "Įveskite knygos pavadinimą")]
        [Display(Name = "Pavadinimas")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Įveskite knygos aprašymą")]
        [Display(Name = "Aprašymas")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Įveskite knygos parašymo metus")]
        [Display(Name = "Metai")]
        public int YearWritten { get; set; }

        [Required(ErrorMessage = "Įveskite šalį, kurioje parašta knyga")]
        [Display(Name = "Šalis")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Įveskite knygos kalbą")]
        [Display(Name = "Kalba")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Įveskite knygos ISBN kodą")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Įveskite knygos išleidimo metus")]
        [Display(Name = "Išleidimo metai")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Įveskite knygos puslapių skaičių")]
        [Display(Name = "Puslapių skaičius")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Įveskite minimalų skaitytojo amžių")]
        [Display(Name = "Minimalus skaitytojo amžius")]
        public int MinAge { get; set; }

        [Required(ErrorMessage = "Įveskite knygos kainą")]
        [Display(Name = "Kaina")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Library Library { get; set; }

        public virtual Publisher Publisher { get; set; }

        [Required]
        public virtual Author Author { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }

        [Required]
        public virtual Condition Condition { get; set; }

        //public virtual List<Reservation> Reservations { get; set; }


        //public virtual IEnumerable<Library> Libraries { get; set; }
        //public virtual IEnumerable<Publisher> Publishers { get; set; }
        //public virtual IEnumerable<Author> Authors { get; set; }
        //public virtual IEnumerable<Genre> Genres { get; set; }
        //public virtual IEnumerable<Condition> Conditions { get; set; }
    }
}
