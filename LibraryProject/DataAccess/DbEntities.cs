using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LibraryProject.Models;

namespace LibraryProject.DataAccess
{
    public class LibraryDB : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
    }
}