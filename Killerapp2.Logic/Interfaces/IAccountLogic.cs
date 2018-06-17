using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;

namespace Killerapp2.Logic.Interfaces
{
    public interface IAccountLogic
    {
        string CheckLoginCredentials(Account acc);
        void CreateUser(Account acc);
        void UpdateBalance(string balance, string accountid);
        Account GetSpecificAccount(Account acc);
    }
}
