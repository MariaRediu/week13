using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleMVC.Models
{
    public class Student
    {
        [Display(Name = "Id")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string  Adress { get; set; }
    }
}