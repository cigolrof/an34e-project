using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace an34e_project.Models {
    public class Customer : BaseClass {
        public string Name { get; set; }
        public string Responsible { get; set; }
	    public int NpsStatus { get; set; }
	    public DateTime CustomerSince { get; set; }
        public DateTime LastAvaliation { get; set; }
    }
}