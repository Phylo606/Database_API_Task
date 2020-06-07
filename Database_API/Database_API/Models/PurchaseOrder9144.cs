using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class PurchaseOrder9144
    {
        public int ProductID { get; set; }
        public string LocationID { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int? Amount { get; set; }
        public decimal? Total { get; set; }

        public virtual Location9144 Location { get; set; }
        public virtual Product9144 Product { get; set; }
    }
}
