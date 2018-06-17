using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;

namespace Killerapp2.DAL.Interfaces
{
    public interface IMonsterRepository
    {
        IEnumerable<MonsterType> GetAllMonster();
        IEnumerable<Element> GetAllElement();
        void NewMonsterType(MonsterType mon, MonsterSprite sprite);
        MonsterType GetDetailMon(string id);
    }
}
