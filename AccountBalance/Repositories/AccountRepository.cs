using AccountBalance.Context;
using AccountBalance.Models;
using AccountBalance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalance.Repositories
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private AccountContext db = new AccountContext();

        #region User
        public UserModel OnGetUser(string username, string password)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
        }
        #endregion

        #region Accounts
        public IEnumerable<AccountModel> GetAll()
        {
            return db.Accounts;
        }

        public void BulkInsertOrUpdate(List<AccountModel> accountModels, string month, int year)
        {
            var existingAccounts = db.Accounts.Where(x => x.Month == month && x.Year == year).ToList();
            if (existingAccounts != null && existingAccounts.Count > 0)
            {
                accountModels.ForEach(x =>
                {
                    var existingAccount = existingAccounts.FirstOrDefault(y => y.AccountName == x.AccountName);
                    if (existingAccount != null)
                    {
                        existingAccount.AccountBalance = x.AccountBalance;
                    }
                    else
                    {
                        db.Accounts.Add(x);
                    }
                });
            }
            else
            {
                db.Accounts.AddRange(accountModels);
            }

            db.SaveChanges();
        }
        #endregion

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}