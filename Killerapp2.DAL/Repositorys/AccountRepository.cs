using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.Domain;

namespace Killerapp2.DAL.Repositorys
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountRepository _iaccountRepository;
        public AccountRepository(IAccountRepository iaccountrepository)
        {
            _iaccountRepository = iaccountrepository;
        }
        public string CheckLoginCredentials(Account acc)
        {
        return _iaccountRepository.CheckLoginCredentials(acc);
        }
        public void CreateUser(Account acc)
        {
            _iaccountRepository.CreateUser(acc );
        }
        public void UpdateBalance(string balance, string accountid)
        {
            _iaccountRepository.UpdateBalance(balance, accountid);
        }
        public Account GetSpecificAccount(Account acc)
        {
            return _iaccountRepository.GetSpecificAccount(acc);
        }
    }
}
