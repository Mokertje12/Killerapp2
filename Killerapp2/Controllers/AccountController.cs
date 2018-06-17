using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Killerapp2.Domain;
using Newtonsoft.Json;
using Killerapp2.Logic;
using Killerapp2.Factory;
using Killerapp2.Logic.Interfaces;
using Killerapp2.Models.ViewModels;

namespace Killerapp2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountLogic _AccountLogic = AccountFactory.CreateSqlLogic();

        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Dashboard()
        {
            if (!HttpContext.Session.Keys.Contains("Account"))
            {
                RedirectToAction("Index", "Home");
            }

            Account acc = GetAccountFromSession();
           

            var model = new AccountDashboardViewModel
            {
                Account = _AccountLogic.GetSpecificAccount(acc)
            };
            return View(model);
        }
        public IActionResult RegistrationSystem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrate(string karakterModel, string gebruikersnaam, string email, string wachtwoord)
        {
            Account acc = new Account(karakterModel, gebruikersnaam, email, wachtwoord);

            try
            {
                _AccountLogic.CreateUser(acc);
                var accObject = acc;
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(accObject));
                return RedirectToAction("LoginForm", "Account");
            }
            catch (Exception e)
            {
                return Ok();
            }
        }
        [HttpPost]
        public IActionResult Login(string usernameAccount, string passwordAccount)
        {
            Account acc = new Account(usernameAccount, passwordAccount);
            try
            {
                string gebruikerId = _AccountLogic.CheckLoginCredentials(acc);
                acc.AccountID = gebruikerId;
                if (gebruikerId != "empty")
                {
                    var accObject = acc;
                    HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(accObject));
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "De gebruikersnaam en/of wachtwoord is onjuist.");
                    return View("LoginForm");
                }
            }
            catch(Exception e)
            {            
                return RedirectToAction("LoginForm");
            }
        }
        private Account GetAccountFromSession()
        {
            var accObject = HttpContext.Session.GetString("Account");


            Account account = new Account();
            if (accObject != null)
                account = JsonConvert.DeserializeObject<Account>(accObject);
            return account;
        }
    }
}
