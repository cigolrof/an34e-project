using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BancoDominio {
    public class Avaliation {
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Month { get; set; }
        public String Year { get; set; }
        public Int32 Area { get; set; }
        public Boolean Finished { get; set; }
        public Int32 Detrators { get; set; }
        public Int32 Neutrals { get; set; }
        public Int32 Promoters { get; set; }
        public Int32 Result { get; set; }
        public List<Customer> AvaliationParticipants { get; set; }
        public Boolean Removed { get; set; }

    }
}