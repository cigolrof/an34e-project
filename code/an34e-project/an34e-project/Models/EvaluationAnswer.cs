using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoNPS.Models
{
    public class EvaluationAnswer : BaseClass
    {
        public int Rating { get; set; }
        public string Answer { get; set; }
        public Evaluation Evaluation { get; set; }
        public Customer Customer { get; set; }
        public DateTime AnswerDate { get; set; }
        public Category Category { get; set; }
    }
}