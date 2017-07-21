using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rest.Models
{
    public class respuesta
    {
        public int code { get; set; }
        public string description { get; set; }
        public string data { get; set; }
    }
}