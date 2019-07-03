using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTTDATALOAD.mvc.Models
{
    public class PTTDATAtype
    {
        public Int64 ID { get; set; }
        public string pop { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string URL { get; set; }
        public string context { get; set; }
    }
}