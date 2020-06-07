using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class Order9144
    {
        public Order9144()
        {
            Orderline9144 = new HashSet<Orderline9144>();
        }
        public int Orderid { get; set; }
        public string Shippingaddress { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimeDispatched { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }

        public virtual AuthorisedPerson9144 User { get; set; }
        public virtual ICollection<Orderline9144> Orderline9144 { get; set; }
    }
}
