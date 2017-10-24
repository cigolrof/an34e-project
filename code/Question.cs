using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPS_MVC.Models
{
    public class Question : BaseModel<Question>
    {
        public String Question { get; set; }
        public Int32 Level { get; set; }        

    }
}