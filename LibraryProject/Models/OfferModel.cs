using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class OfferModel
    {
        public int Id { get; set; }
        public PublisherModel Publisher { get; set; }
        public double Price { get; set; }
        public BookModel Book { get; set; }
    }
}