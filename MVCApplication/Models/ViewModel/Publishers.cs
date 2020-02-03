using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.WebPages.Html;
using MVCApplication.Models.BD;

namespace MVCApplication.Models.ViewModel
{
    public class Publishers
    {
        public int PublisherID { get; set; }

        [Column("PublisherName")]
        [Display(Name = "Publisher of Book")]
        public string PublisherName { get; set; }
        public string Country { get; set; }
        public int NumberOfBooks { get; set; }
        public  virtual ICollection<Books> Book { get; }
    }
}