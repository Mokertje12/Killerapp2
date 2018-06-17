using System;
using System.Collections.Generic;
using System.Text;

namespace Killerapp2.Domain
{
    public class MonsterType
    {
        public string ID { get; set; }
        public string Naam { get; set; }
        public string SpriteID { get; set; }
        public string LevelRangeHoogste { get; set; }
        public string LevelRangeLaagste { get; set; }
        public string ElementID { get; set; }
        public string Vangkans { get; set; }
        public string Path { get; set; }
        public string ElementNaam { get; set; }
        public string ElementKleur { get; set; }
        public MonsterType(string naam, string spriteid, string levelrangehoogste, string levelrangelaagste, string elementid, string vangkans)
        {
            Naam = naam;
            SpriteID = spriteid;
            LevelRangeHoogste = levelrangehoogste;
            LevelRangeLaagste = levelrangelaagste;
            ElementID = elementid;
            Vangkans = vangkans;
        }
        public MonsterType()    
        {

        }
    }
}
