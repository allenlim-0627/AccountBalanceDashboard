using AccountBalance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountBalance.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext() :
         base("dbConnectionString")
        {
        }

        public static AccountContext Create()
        {
            return new AccountContext();
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<UserModel> Users { get; set; }


    }
}