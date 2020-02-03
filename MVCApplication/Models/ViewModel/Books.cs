using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVCApplication.Models.ViewModel
{
    public class Books
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Name of book")]
        public string BookName { get; set; }
       
        [Column("Detail")]
        [Display(Name = "Detail")]
        public string Detail { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
  
        [Display(Name = "Quantities")]
        public int Quantities { get; set; }
        public string Images { get; set; }

        [Display(Name = "Author")]
       public IEnumerable<SelectListItem>  Author_ID { get; set; }

        [Display(Name = "Name Publisher")]
        public IEnumerable<SelectListItem> Publisher_ID { get; set; }

        public virtual Publishers Publisher { get; set; }
        public virtual Author Author { get; set; }
        // public IEnumerable<Author> Author { get; set; }

    }
}