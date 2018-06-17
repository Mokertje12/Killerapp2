using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.Domain;

namespace Killerapp2.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Product GetDetailPro(string id);
        void InsertIntoOrder(Order order);
    }
}
