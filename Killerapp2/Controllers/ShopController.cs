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
    public class ShopController : Controller
    {
        private readonly IProductLogic _ProductLogic = ProductFactory.CreateSqlLogic();
        private readonly IAccountLogic _AccountLogic = AccountFactory.CreateSqlLogic();

        public IActionResult Winkelpagina()
        {
            var model = new GetProductViewModel()
            {
                Product = _ProductLogic.GetAllProduct().ToList()
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            Product pro = _ProductLogic.GetDetailPro(id);
            ProDetailViewModel model = new ProDetailViewModel
            {
                Product = pro,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Afrekenen(string id)
        {
            if (!HttpContext.Session.Keys.Contains("Account"))
            {
                RedirectToAction("Index", "Home");
            }
            Product pro = _ProductLogic.GetDetailPro(id);
            Account acc = GetAccountFromSession();
            Account newacc = _AccountLogic.GetSpecificAccount(acc);
            Order order = new Order(acc.AccountID, pro.ID, Convert.ToString(DateTime.Now), pro.Naam);
            _ProductLogic.InsertIntoOrder(order);
            int newbalance = (Convert.ToInt32(newacc.Balance))-(Convert.ToInt32(pro.Price));
            _AccountLogic.UpdateBalance(Convert.ToString(newbalance), acc.AccountID);

            return RedirectToAction("Winkelpagina");
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
