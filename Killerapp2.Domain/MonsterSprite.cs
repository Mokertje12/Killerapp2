using System;
using System.Collections.Generic;
using System.Text;

namespace Killerapp2.Domain
{
    public class MonsterSprite
    {
        public string ID { get; set; }
        public string Path { get; set; }

        public MonsterSprite(string id, string path)
        {
            ID = id;
            Path = path;
        }
    }
}
