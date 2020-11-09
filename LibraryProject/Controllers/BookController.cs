using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        static AuthorModel putinas = new AuthorModel { Name = "Vincas", Surname = "Mykolaitis-Putinas" };
        static AuthorModel antanas_skema = new AuthorModel { Name = "Antanas", Surname = "Škėma" };
        static AuthorModel balys_sruoga = new AuthorModel { Name = "Balys", Surname = "Sruoga" };
        static AuthorModel dzeromas = new AuthorModel { Name = "Jerome", Surname = "Salinger" };

        static BookModel book1 = new BookModel
        {
            Author = putinas,
            Title = "Altorių šešėly",
            YearWritten = 1933,
            Description = "Tai buvo pirmasis tokio pobūdžio kūrinys lietuvių literatūroje. Jame aprašomas Liudo Vasario – jauno kunigo - gyvenimas, jausmai, vidiniai konfliktai, siekis išsivaduoti iš visuomenės primestų dogmų. Kūrinyje sprendžiama labai daug psichologinių problemų: kunigystės, gyvenimo kelio ieškojimo, menininko asmenybės laisvės. Ypač ryškus romano motyvas – ar gali tas pats žmogus būti ir kunigas, ir poetas?",
            ISBN = "9789955081456"
        };
        static BookModel book2 = new BookModel
        {
            Author = antanas_skema,
            Title = "Balta drobulė",
            YearWritten = 1958,
            Description = "Antanas Garšva dirba liftininku viename didžiausių Niujorko viešbučių. Jį slegia uniforma, bukinantis darbas, vienatvė, kamuoja egzistenciniai klausimai, kūrybinės kančios ir, regis, jis tuoj, tuoj išprotės.",
            ISBN = "9789986026976"
        };
        static BookModel book3 = new BookModel
        {
            Author = balys_sruoga,
            Title = "Dievų miškas",
            YearWritten = 1945,
            Description = "Dievų miškas – memuarų knyga, parašyta 1945 m. lietuvių rašytojo ir poeto Balio Sruogos (1896–1947).",
            ISBN = "9789986394167"
        };
        static BookModel book4 = new BookModel
        {
            Author = dzeromas,
            Title = "Rugiuose prie bedugnės",
            YearWritten = 1951,
            Description = "Kūrinys, iš pradžių skirtas suaugusiems skaitytojams, susilaukė didžiulio pasisekimo jaunimo tarpe. Šiuo metu knyga „Rugiuose prie bedugnės“ labai dažnai įtraukiama į mokyklų mokymo programas, ji – viena iš moksleiviams rekomenduojamų perskaityti knygų. Pirmuoju asmeniu pasakojamoje istorijoje perteikiami pagrindinio veikėjo Houldeno išgyvenimai Niujorke, pasaulis iš paauglio perspektyvos.",
            ISBN = "9780241900970"
        };

        public ActionResult Index()
        {
            List<BookModel> books = new List<BookModel>
            {
                book1,
                book2,
                book3,
                book4
            };

            return View(books);
        }

        public ActionResult Details(string ISBN)
        {
            return View(book1);
        }

        public ActionResult NewBookForm()
        {
            return View();
        }
        
    }
}
