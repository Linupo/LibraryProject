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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Explanation { get; set; }
        

    }
}