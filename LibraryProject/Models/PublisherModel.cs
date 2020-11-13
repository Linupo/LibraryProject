using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class PublisherModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Leidėjas")]
        public string Title { get; set; }
        [DisplayName("Adresas")]
        public string Address { get; set; }
    }
}