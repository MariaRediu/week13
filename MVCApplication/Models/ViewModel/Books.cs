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

        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }
       
        [DisplayName("Detail")]
        public string Detail { get; set; }
        [DisplayName ("Price")]
        public decimal Price { get; set; }
  
        [DisplayName("Quantities")]
        public int Quantities { get; set; }
        public string Images { get; set; }

        [DisplayName("Author")]
        public int AuthorID { get; set; }

        [DisplayName("Name Publisher")]
        public int PublisherID { get; set; }

       
    }
}