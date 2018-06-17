using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.DAL.Base;
using Killerapp2.Domain;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Killerapp2.DAL.Contexts
{
    public class AccountSqlContext : BaseRepository, IAccountRepository
    {
        public string CheckLoginCredentials(Account acc)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string gebruikerId = "";
                try
                {
                    gebruikerId = GetAccountID(db, new Account(acc.Gebruikersnaam, acc.Wachtwoord));
                    return gebruikerId;
                }
                catch
                {
                    return "empty";
                }
            }
        }
        public Account GetSpecificAccount(Account acc)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query = $"SELECT * FROM Gebruiker WHERE ID  = '{acc.AccountID}'";
                return db.QuerySingle<Account>(query);
            }
        }
        private string GetAccountID(IDbConnection db, Account account)
        {
            string sQuery =
                $"SELECT ID FROM Gebruiker WHERE Gebruikersnaam = '{account.Gebruikersnaam}' AND Wachtwoord = '{account.Wachtwoord}'";
            return db.QuerySingle<string>(sQuery);
        }

        public void CreateUser(Account acc)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();

                //string Query =
                //    $"INSERT INTO Gebruiker (Karaktermodel, Gebruikersnaam, Email, Wachtwoord, Balance) VALUES ('{acc.KarakterModel}', '{acc.Gebruikersnaam}', '{acc.Email}', '{acc.Wachtwoord}', '100')";
                //db.Execute(Query);

                db.Execute("NewAccount",
                new
                {
                    Karaktermodel = acc.KarakterModel,
                    Gebruikersnaam = acc.Gebruikersnaam,
                    Email = acc.Email,
                    Wachtwoord = acc.Wachtwoord,
                    Balance = "100",
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateBalance(string balance, string accountid)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();

                string Query =
                    $"UPDATE Gebruiker SET Balance = '{balance}' WHERE ID = '{accountid}'";
                db.Execute(Query);
            }
        }
    }
}
