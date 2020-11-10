using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class WorkerModel
    {
        public TemplateModel Template { get; set; }
        public string Tier { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Id { get; set; }
    }
}