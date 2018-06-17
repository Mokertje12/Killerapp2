using Microsoft.Extensions.Configuration;
using Killerapp2.DAL.Contexts;
using Killerapp2.DAL.Repositorys;
using Killerapp2.Logic.Interfaces;
using Killerapp2.Logic.Logics;

namespace Killerapp2.Factory
{
    public class AccountFactory
    {
        public static IAccountLogic CreateSqlLogic()
        {
            return new AccountLogic(new AccountRepository(new AccountSqlContext()));
        }
    }
}
