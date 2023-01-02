using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalance.Models
{
    public class AccountDTO
    {
        public string AccountName { get; set; }
        public string AccountBalance { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}