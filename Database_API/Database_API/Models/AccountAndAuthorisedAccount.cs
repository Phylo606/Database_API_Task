using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_API.Models
{
    public class AccountAndAuthorisedAccount
    {
        [Key]
        public int acctID { get; set; }
        public string acctName { get; set; }
        public decimal acctBalance { get; set; }
        public decimal credLimit { get; set; }

        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
