using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;

namespace Killerapp2.DAL.Interfaces
{
    public interface IAccountRepository
    {
        string CheckLoginCredentials(Account log);
        void CreateUser(Account acc);
        void UpdateBalance(string balance, string accountid);
        Account GetSpecificAccount(Account acc);
    }
}
