using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Models
{
    public class RealTimeUpdate
    {
        public long Subscription_Id { get; set; }
        public string @object { get; set; }
        public string Object_Id { get; set; }
        public string Changed_Aspect { get; set; }
        public long Time { get; set; }
        public RealTimeUpdateData Data { get; set; }
    }
}
