using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.IO;
using Killerapp2.DAL.Interfaces;
using Killerapp2.Domain;
using Killerapp2.Logic.Interfaces;

namespace Killerapp2.Logic.Logics
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productrepo;

        public ProductLogic(IProductRepository productRepo)
        {
            _productrepo = productRepo;
        }
        public IEnumerable<Product> GetAllProduct()
        {
            List<Product> product = _productrepo.GetAllProduct().AsList();
            product.ForEach(x => x.Path = "/images/" + x.Path);
            return product;
        }
        public Product GetDetailPro(string id)
        {
            Product product = _productrepo.GetDetailPro(id);
            product.Path = "/images/" + product.Path;
            return product;
        }
        public void InsertIntoOrder(Order order)
        {
            _productrepo.InsertIntoOrder(order);
        }
    }
}
