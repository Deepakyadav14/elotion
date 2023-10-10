using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elotion.Models
{
    public class model
    {
        public int id { get; set; }
        public string product { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int total { get; set; }

    }
}