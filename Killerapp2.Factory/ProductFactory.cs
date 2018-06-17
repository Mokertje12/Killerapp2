using Microsoft.Extensions.Configuration;
using Killerapp2.DAL.Contexts;
using Killerapp2.DAL.Repositorys;
using Killerapp2.Logic.Interfaces;
using Killerapp2.Logic.Logics;

namespace Killerapp2.Factory
{
    public class ProductFactory
    {
        public static IProductLogic CreateSqlLogic()
        {
            return new ProductLogic(new ProductRepository(new ProductSqlContext()));
        }
    }
}
