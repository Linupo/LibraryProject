using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }

        [Display(Name = "Pavadinimas")]
        [Required(ErrorMessage = "Įveskite pavadinimą")]
        public string Title { get; set; }

        [Display(Name = "Aprašymas")]
        [Required(ErrorMessage = "Įveskite aprašymą")]
        public string Description { get; set; }

        [Display(Name = "Metai")]
        [Required(ErrorMessage = "Įveskite parašymo metus")]
        public int YearWritten { get; set; }

        [Display(Name = "Šalis")]
        [Required(ErrorMessage = "Įveskite kur knyga parašyta")]
        public string Country { get; set; }

        [Display(Name = "Kalba")]
        [Required(ErrorMessage = "Įveskite knygos parašymo kalbą")]
        public string Language { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Įveskite knygos ISBN kodą")]
        public string ISBN { get; set; }

        [Display(Name = "Išleidimo data")]
        [Required(ErrorMessage = "Įveskite knygos išleidimo datą")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Puslapių skaičius")]
        [Required(ErrorMessage = "Įveskite knygos puslapių skaičių")]
        public int PageCount { get; set; }

        [Display(Name = "Minimalus amžius, kad skaityti knygą")]
        [Required(ErrorMessage = "Įveskite minimalų knygos skaitymo amžių")]
        public int MinAge { get; set; }

        [Display(Name = "Kaina")]
        [Required(ErrorMessage = "Įveskite knygos kainą")]
        public int Price { get; set; }

        [Display(Name = "Žanras")]
        [Required(ErrorMessage = "Įveskite kur knygos žanrą")]
        public int GenreId { get; set; }

        [Display(Name = "Būklė")]
        [Required(ErrorMessage = "Įveskite knygos būklę")]
        public int ConditionId { get; set; }

        public string GetGenre()
        {
            switch(GenreId)
            {
                case 1:
                    return "Nuotykiai";
                case 2:
                    return "Biografija";
                case 3:
                    return "Fantastika";
                case 4:
                    return "Romanas";
                case 5:
                    return "Drama";
                case 6:
                    return "Apysaka";
                case 7:
                    return "Legenda";
                case 8:
                    return "Padavimas";
            }
            return "no genre";
        }
    }
}