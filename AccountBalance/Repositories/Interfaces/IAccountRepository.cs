using AccountBalance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalance.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        UserModel OnGetUser(string username, string password);

        List<AccountModel> GetAll();

        void BulkInsertOrUpdate(List<AccountModel> accountModels, string month, int year);
    }
}
