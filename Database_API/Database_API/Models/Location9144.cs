using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class Location9144
    {
        public Location9144()
        {
            Inventory9144 = new HashSet<Inventory9144>();
            PurchaseOrder9144 = new HashSet<PurchaseOrder9144>();
        }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public virtual ICollection<Inventory9144> Inventory9144 { get; set; }
        public virtual ICollection<PurchaseOrder9144> PurchaseOrder9144 { get; set; }
    }
}
