using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class OfferModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Leidėjas")]
        public PublisherModel Publisher { get; set; }
        [DisplayName("Kaina")]
        public double Price { get; set; }
        [DisplayName("Kiekis")]
        public int Amount { get; set; }
        [DisplayName("Stadija")]
        public string Stage { get; set; }
        [DisplayName("Knyga")]
        public BookModel Book { get; set; }
    }
}