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
    public class GameController : Controller
    {
        public IActionResult Game()
        {
            return View();
        }
        public IActionResult Encounter()
        {
            return RedirectToAction("Dashboard", "Account");
        }
    }
}
