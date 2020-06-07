using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class Orderline9144
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Order9144 Order { get; set; }
        public virtual Product9144 Product { get; set; }
    }
}
