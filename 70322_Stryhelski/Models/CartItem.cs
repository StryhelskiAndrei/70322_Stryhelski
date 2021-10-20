using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _70322_Stryhelski.DAL;

namespace _70322_Stryhelski.Models
{
    public class CartItem
    {
        public Film Film { get; set; }
        public int Count { get; set; }
    }
}