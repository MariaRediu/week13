using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVCApplication.Models.ViewModel
{
    public class Books{

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }      
        public string BookName { get; set; }    
        public string Detail { get; set; }      
        public decimal Price { get; set; }      
        public int Quantities { get; set; }
        public string Images { get; set; }     
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public IEnumerable<SelectListItem> Publisher { get; set; }
        
    }
}