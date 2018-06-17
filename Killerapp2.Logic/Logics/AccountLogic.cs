using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.Domain;
using Killerapp2.Logic.Interfaces;

namespace Killerapp2.Logic.Logics
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountRepository _accountrepo;

        public AccountLogic(IAccountRepository accRepo)
        {
            _accountrepo = accRepo;
        }
        public string CheckLoginCredentials(Account acc)
        {
            return _accountrepo.CheckLoginCredentials(acc);
        }
        public void CreateUser(Account acc)
        {
            _accountrepo.CreateUser(acc);
        }
        public void UpdateBalance(string balance, string accountid)
        {
            _accountrepo.UpdateBalance(balance, accountid);
        }
        public Account GetSpecificAccount(Account acc)
        {
            Account account = _accountrepo.GetSpecificAccount(acc);
            return account;
        }
    }
}
