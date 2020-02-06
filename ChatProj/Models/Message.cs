using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatProj.Models
{
    public class Message
    {
        
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string MessageString { get; set; }
        public DateTime MessageDate { get; set; }

    }
}