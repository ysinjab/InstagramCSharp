using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Models
{
    public class Media
    {
        public string Type { get; set; }

        public Location Location { get; set; }
        public Comments Comments { get; set; }
        public Likes Likes { get; set; }
        public string Filter { get; set; }
        public long Created_Time { get; set; }
        public string Link { get; set; }

        public Images images { get; set; }
        public Videos videos { get; set; }
        public List<UserInPhoto> users_in_photo { get; set; }
        public Caption Caption { get; set; }
        public bool User_Has_Liked { get; set; }
        public string id { get; set; }
        public User user { get; set; }
    }

}
