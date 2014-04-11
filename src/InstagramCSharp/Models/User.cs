using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Models
{    
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Full_Name { get; set; }
        public string Profile_Picture { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public Counts Counts { get; set; }
    }

}
