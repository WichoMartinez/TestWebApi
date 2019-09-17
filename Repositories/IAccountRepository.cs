using StoreApi.Models;
using System.Collections.Generic;

namespace StoreApi.Repository
{
    public interface IAccountRepository
    {

        List<Account> GetAllAccounts();

        Account CreateAccount(Account account);

    }
}