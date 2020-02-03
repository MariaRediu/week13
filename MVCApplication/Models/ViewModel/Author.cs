﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVCApplication.Models.ViewModel
{
    public class Author
    {
        public IEnumerable<SelectListItem> AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Years { get; set; }
        public virtual ICollection<Books> Book { get; set; }
    }
}