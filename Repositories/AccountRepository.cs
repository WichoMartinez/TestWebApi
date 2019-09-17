using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Repository
{
    public class AccountRepository: IAccountRepository
    {

        private readonly StoresContext _context;

        public AccountRepository(StoresContext db)
        {
            _context = db;
        }
        public List<Account> GetAllAccounts()
        {
            return _context.Account.AsNoTracking().ToList();
        }

        public Account CreateAccount(Account account)
        {
            //var places = _context.Places.FromSql("dbo.GetPlacesByCategory @p0 @p0 ", Id, Name, Email, NotifyNewPlace);
            return account;
        }
    }

    
}
