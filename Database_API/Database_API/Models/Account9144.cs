using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API.Models
{
    public partial class Account9144
    {
        public Account9144()
        {
            Payment9144 = new HashSet<Payment9144>();
            AuthorisedPerson9144 = new HashSet<AuthorisedPerson9144>();
            AuthorisedAccounts9144 = new HashSet<AuthorisedAccounts9144>();
        }
        public int acctId { get; set; }
        public string acctName { get; set; }
        public decimal acctBalance { get; set; }
        public decimal credLimit { get; set; }
        public virtual ICollection<Payment9144> Payment9144 { get; set; }
        public virtual ICollection<AuthorisedPerson9144> AuthorisedPerson9144 { get; set; }
        public virtual ICollection<AuthorisedAccounts9144> AuthorisedAccounts9144 { get; set; } 
    }
}
