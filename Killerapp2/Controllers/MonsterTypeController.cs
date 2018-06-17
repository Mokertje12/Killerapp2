using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Killerapp2.Domain;
using Newtonsoft.Json;
using Killerapp2.Logic;
using Killerapp2.Factory;
using Killerapp2.Models.ViewModels;
using Killerapp2.Logic.Interfaces;

namespace Killerapp2.Controllers
{
    public class MonsterTypeController : Controller
    {
        private readonly IMonsterTypeLogic _iMonsterTypeLogic = MonsterTypeFactory.CreateSqlLogic();

        public IActionResult Monsterlijst()
        {
            var model = new GetMonsterTypeViewModel()
            {
                Monstertype = _iMonsterTypeLogic.GetAllMonster().ToList(),
                Element = _iMonsterTypeLogic.GetAllElement().ToList()
            };

            return View(model);
        }
         public IActionResult MonsterForm()
        {
            var model = new GetMonsterTypeViewModel()
            {
                Monstertype = _iMonsterTypeLogic.GetAllMonster().ToList(),
                Element = _iMonsterTypeLogic.GetAllElement().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Post(string nameMonster, IFormFile photoMonster,
            string lowLevelMonster, string highLevelMonster, string vangkansMonster, string elementMonster)
        {
            try
            {
                if (photoMonster != null)
                {
                    var path = Path.Combine
                    (
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "images",
                        photoMonster.FileName
                    );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await photoMonster.CopyToAsync(stream);
                    }
                }

                MonsterType mon = new MonsterType(nameMonster, Guid.NewGuid().ToString(),
                    highLevelMonster, lowLevelMonster, elementMonster, vangkansMonster);
                MonsterSprite sprite = new MonsterSprite(mon.SpriteID, photoMonster.FileName);

                _iMonsterTypeLogic.NewMonsterType(mon, sprite);
                return RedirectToAction("Monsterlijst");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            var accObject = HttpContext.Session.GetString("Account");

            MonsterType mon = _iMonsterTypeLogic.GetDetailMon(id);
            MonDetailViewModel model = new MonDetailViewModel
            {
                Monstertype = mon,
            };
            return View(model);
        }
    }
}
