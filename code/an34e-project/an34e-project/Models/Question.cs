using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace an34e_project.Models {
    public class Question {
        public int id { get; set; }
        public string question { get; set; }
        public int level { get; set; }
        public int level_required { get; set; }
        public int removed { get; set; }
    }
}