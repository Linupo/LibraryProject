using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class AuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}