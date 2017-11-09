using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BancoDominio {
    public class AvaliationsParticipants {
        public Int32 Id { get; set; }
        public Avaliation Avaliation { get; set; }
        public Customer Customer { get; set; }
        public Question Question { get; set; }
        public Int32 Score { get; set; }
        public String Feedback { get; set; }
        public Boolean IsValid { get; set; }
        public Boolean Finished { get; set; }
        public Int32 Area { get; set; }
        public String Justificate { get; set; }
        public String FeedbackCategory { get; set; }
    }
}