using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.DAL.Base;
using Killerapp2.Domain;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Killerapp2.DAL.Contexts
{
    public class MonsterTypeSqlContext : BaseRepository, IMonsterRepository
    {

        public IEnumerable<MonsterType> GetAllMonster()
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query = "SELECT MonsterType.ID, MonsterType.Naam, MonsterType.SpriteID, MonsterType.LevelRangeHoogste, MonsterType.LevelRangeLaagste, MonsterType.ElementID, MonsterType.Vangkans, s.Path, e.ElementNaam, e.ElementKleur FROM MonsterType" +
                    " INNER JOIN MonsterSprite s ON MonsterType.SpriteID = s.ID" +
                    " INNER JOIN Element e ON MonsterType.ElementID = e.ID";
                return db.Query<MonsterType>(query);
            }
        }
        public IEnumerable<Element> GetAllElement()
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query =
                    "Select ID, ElementNaam, EffectiefID, IneffectiefID, ElementKleur FROM Element";
                return db.Query<Element>(query);
            }
        }
        public void NewMonsterType(MonsterType mon, MonsterSprite sprite)
        {
            using (IDbConnection db = OpenConnection())
            {
                if (mon.SpriteID != null)
                {
                        string s1Query = $"INSERT INTO MonsterSprite VALUES('{sprite.ID}', '{sprite.Path}')";
                        db.Execute(s1Query);

                        string s2Query =
                            $"INSERT INTO MonsterType VALUES('{mon.Naam}', '{mon.SpriteID}', '{mon.LevelRangeHoogste}', '{mon.LevelRangeLaagste}', '{mon.ElementID}', '{mon.Vangkans}')";
                        db.Execute(s2Query);
                }
            }
        }
        public MonsterType GetDetailMon(string id)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query = $"SELECT m.ID, m.Naam, m.SpriteID, m.LevelRangeHoogste, m.LevelRangeLaagste, m.ElementID, m.Vangkans, s.Path, e.ElementNaam, e.ElementKleur FROM MonsterType m, MonsterSprite s, Element e WHERE m.ID  = '{id}' AND m.SpriteID = s.ID AND m.ElementID = e.ID";
                return db.QuerySingle<MonsterType>(query);
            }
        }
    }
}
