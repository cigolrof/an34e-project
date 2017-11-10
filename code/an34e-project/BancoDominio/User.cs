using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDominio {
    public class User {
        public Int32 Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public Boolean isAdmin { get; set; }
        public Boolean Removed { get; set; }
    }
}
