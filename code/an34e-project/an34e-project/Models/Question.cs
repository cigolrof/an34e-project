using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace an34e_project.Models {
    public class Question {
        public Int32 Id { get; set; }
        public String Quest { get; set; }
        public Int32 Level { get; set; }
        public Int32 RequiredLevel { get; set; }
        public Boolean Removed { get; set; }
    }
}