using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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

        [Column("Price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Column("Quantities")]
        [Display(Name = "Quantities")]
        public int Quantities { get; set; }

        public string Images { get; set; }

        [Column(" Author of Book")]
        [Display(Name = " Author of Book")]
       public int Author_ID { get; set; }

        [Column(" Publisher")]
        [Display(Name = "Publisher")]
        public int Publisher_ID { get; set; }
    }
}