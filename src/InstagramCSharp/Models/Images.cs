using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Models
{
    public class Images
    {
        public LowResolution Low_Resolution { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public StandardResolution Standard_Resolution { get; set; }
    }
}
