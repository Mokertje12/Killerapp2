using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;
using Killerapp2.DAL.Interfaces;
using Killerapp2.DAL.Base;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Killerapp2.DAL.Contexts
{
    public class MonsterTypeMomeryContext : IMonsterRepository
    {
        public IEnumerable<Element> GetAllElement()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MonsterType> GetAllMonster()
        {
            throw new NotImplementedException();
        }

        public MonsterType GetDetailMon(string id)
        {
            throw new NotImplementedException();
        }

        public void NewMonsterType(MonsterType mon, MonsterSprite sprite)
        {
            throw new NotImplementedException();
        }
    }
}
