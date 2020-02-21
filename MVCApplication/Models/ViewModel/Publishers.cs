using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApplication.Models.ViewModel
{
    public class Publishers
    {
        public int PublisherID { get; set; }

        [Display(Name="Publisher Name")]
        public string PublisherName { get; set; }
        public string Country { get; set; }
        public int NumberOfBooks { get; set; }
    }
}