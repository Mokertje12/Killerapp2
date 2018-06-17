using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.Domain;

namespace Killerapp2.DAL.Repositorys
{
    public class MonsterTypeRepository : IMonsterRepository
    {
        private readonly IMonsterRepository _imonstertypeRepository;
        public MonsterTypeRepository(IMonsterRepository imonstertypeRepository)
        {
            _imonstertypeRepository = imonstertypeRepository;
        }
        public IEnumerable<MonsterType> GetAllMonster()
        {
            return _imonstertypeRepository.GetAllMonster();
        }
        public IEnumerable<Element> GetAllElement()
        {
            return _imonstertypeRepository.GetAllElement();
        }
        public void NewMonsterType(MonsterType mon, MonsterSprite sprite)
        {
            _imonstertypeRepository.NewMonsterType(mon, sprite);
        }
        public MonsterType GetDetailMon(string id)
        {
            return _imonstertypeRepository.GetDetailMon(id);
        }
    }
}
