using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountBalance.Models
{
    public class AccountModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AccountName { get; set; }
        public string AccountBalance { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}