using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPS_MVC.Models
{
    public class Customer : BaseModel<Customer>
    {
        public String Name { get; set; }
        public String Responsible { get; set; }
        public Int32 Area { get; set; }
        public Int32 NpsStatus { get; set; }
        public DateTime CustomerSince { get; set; }
        public DateTime? LastAvaliation { get; set; }

    }
}