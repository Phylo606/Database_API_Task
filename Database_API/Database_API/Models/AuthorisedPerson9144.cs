using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Database_API.Models
{
    public partial class AuthorisedPerson9144
    {
        public AuthorisedPerson9144()
        {
            AuthorisedAccounts9144 = new HashSet<AuthorisedAccounts9144>();
            Order9144 = new HashSet<Order9144>();

        }
        public int userID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int accountID { get; set; }

        public virtual Account9144 Account { get; set; }
        public virtual ICollection<AuthorisedAccounts9144> AuthorisedAccounts9144 { get; set; }
        public virtual ICollection<Order9144> Order9144 { get; set; }
    }
}
