using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class ComputerModel
    {
        [DisplayName("ID")]
        [Required]
        public int kodas { get; set; }
        [DisplayName("Vaizdo plokštė")]
        [Required]
        public string vaizdo_plokste { get; set; }
        [DisplayName("Procesorius")]
        [Required]
        public string procesorius { get; set; }
        [DisplayName("Monitorius")]
        [Required]
        public string monitorius { get; set; }
    }
}