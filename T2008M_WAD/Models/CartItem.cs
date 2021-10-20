using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T2008M_WAD.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Qty { get; set; }
    }
}