using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    public class Envelope<T> where T : class
    {
        public Meta Meta { get; set; }
        public T Data { get; set; }
        public Pagination Pagination { get; set; }
    }
}
