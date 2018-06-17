using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp2.Domain;

namespace Killerapp2.Models.ViewModels
{
    public class GetMonsterTypeViewModel
    {
        public List<MonsterType> Monstertype { get; set; }
        public List<Element> Element { get; set; }
    }
}
