using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Database_API.Models
{
    public partial class AuthorisedAccounts9144
    {
        public int Accountid { get; set; }
        public string acctName { get; set; }
        public decimal acctBalance { get; set; }
        public decimal credLimit { get; set; }
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Account9144 Account { get; set; }
        public virtual AuthorisedPerson9144 User { get; set; }
    }
}
