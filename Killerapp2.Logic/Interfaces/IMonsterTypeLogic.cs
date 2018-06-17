using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;

namespace Killerapp2.Logic.Interfaces
{
    public interface IMonsterTypeLogic
    {
        IEnumerable<MonsterType> GetAllMonster();
        IEnumerable<Element> GetAllElement();
        MonsterType GetDetailMon(string id);
        void NewMonsterType(MonsterType mon, MonsterSprite sprite);
    }
}
