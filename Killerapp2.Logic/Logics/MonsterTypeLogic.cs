using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.IO;
using Killerapp2.DAL.Interfaces;
using Killerapp2.Domain;
using Killerapp2.Logic.Interfaces;

namespace Killerapp2.Logic.Logics
{
    public class MonsterTypeLogic : IMonsterTypeLogic
    {
        private readonly IMonsterRepository _monstertyperepo;

        public MonsterTypeLogic(IMonsterRepository monsterRepo)
        {
            _monstertyperepo = monsterRepo;
        }
        public IEnumerable<Element> GetAllElement()
        {
            List<Element> element = _monstertyperepo.GetAllElement().AsList();
            return element;
        }
        public IEnumerable<MonsterType> GetAllMonster()
        {
            List<MonsterType> monstertype = _monstertyperepo.GetAllMonster().AsList();
            monstertype.ForEach(x => x.Path = "/images/" + x.Path);
            return monstertype;
        }
        public void NewMonsterType(MonsterType mon, MonsterSprite sprite)
        {
            _monstertyperepo.NewMonsterType(mon, sprite);
        }
        public MonsterType GetDetailMon(string id)
        {
            MonsterType monstertype = _monstertyperepo.GetDetailMon(id);
            monstertype.Path = "/images/" + monstertype.Path;
            return monstertype;
        }
    }
}
