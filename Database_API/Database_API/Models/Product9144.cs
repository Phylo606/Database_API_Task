using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class Product9144
    {
        public Product9144()
        {
            Inventory9144 = new HashSet<Inventory9144>();
            Orderline9144 = new HashSet<Orderline9144>();
            PurchaseOrder9144 = new HashSet<PurchaseOrder9144>();
        }

        public int Productid { get; set; }
        public string Prodname { get; set; }
        public decimal? Buyprice { get; set; }
        public decimal? Sellprice { get; set; }

        public virtual ICollection<Inventory9144> Inventory9144 { get; set; }
        public virtual ICollection<Orderline9144> Orderline9144 { get; set; }
        public virtual ICollection<PurchaseOrder9144> PurchaseOrder9144 { get; set; }
    }
}
