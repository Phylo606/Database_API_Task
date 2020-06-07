using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class Payment9144
    {
        public int ID { get; set; }
        public DateTime TimeRecieved { get; set; }
        public decimal Sum { get; set; }
        public virtual Account9144 Account { get; set; }
    }
}
