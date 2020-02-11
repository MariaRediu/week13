using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Models.ViewModel
{
    public class Publishers
    {
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
        public string Country { get; set; }
        public int NumberOfBooks { get; set; }
    }
}