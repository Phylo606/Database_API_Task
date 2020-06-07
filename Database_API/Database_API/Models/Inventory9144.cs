using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Database_API.Models
{
    public partial class Inventory9144
    {
        public int ProductID { get; set; }
        public string LocationID { get; set; }
        public int Stock { get; set; }
        public virtual Location9144 Location { get; set; }
        public virtual Product9144 Product { get; set; }
    }
}
