using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videos.Models
{
    public class videos
    {
        public virtual int id { get; set; }
        public virtual string title { get; set; }
        public virtual int length { get; set; }
    }
}