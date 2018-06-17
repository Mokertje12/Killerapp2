 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Killerapp2.Domain
{
    public class Account
    {
        public string AccountID { get; set; }
        public string KarakterModel { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Balance { get; set; }

        public Account(string gebruikersnaam, string wachtwoord)
        {
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
        }
        public Account(string accountId, string gebruikersnaam, string wachtwoord)
        {
            AccountID = accountId;
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
        }
        public Account(string karakterModel, string gebruikersnaam, string email, string wachtwoord)
        {
            KarakterModel = karakterModel;
            Gebruikersnaam = gebruikersnaam;
            Email = email;
            Wachtwoord = wachtwoord;
        }
        public Account()
        {

        }
    }
}
