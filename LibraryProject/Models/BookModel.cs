using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class BookModel
    {
        public AuthorModel Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearWritten { get; set; }
        public string ISBN { get; set; }
    }
}