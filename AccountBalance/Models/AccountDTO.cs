using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalance.Models
{
    public class AccountDTO
    {
        //public int Id { get; set; }
        //public string FileTitle { get; set; }
        [Index(0)]
        public string AccountName { get; set; }
        [Index(1)]
        public string AccountBalance { get; set; }
    }
}