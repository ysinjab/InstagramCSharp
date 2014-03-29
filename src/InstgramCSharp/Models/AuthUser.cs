using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Models
{
    public class AuthUser
    {
        public string access_token { get; set; }
        public User user { get; set; }
    }
}
