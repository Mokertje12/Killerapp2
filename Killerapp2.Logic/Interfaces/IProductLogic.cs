using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;

namespace Killerapp2.Logic.Interfaces
{
    public interface IProductLogic
    {
        IEnumerable<Product> GetAllProduct();
        Product GetDetailPro(string id);
        void InsertIntoOrder(Order order);
    }
}
