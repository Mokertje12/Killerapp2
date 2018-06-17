using System;
using System.Collections.Generic;
using System.Text;
using Killerapp2.DAL.Interfaces;
using Killerapp2.Domain;

namespace Killerapp2.DAL.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductRepository _iproductrepository;
        public ProductRepository(IProductRepository iproductRepository)
        {
            _iproductrepository = iproductRepository;
        }
        public IEnumerable<Product> GetAllProduct()
        {
            return _iproductrepository.GetAllProduct();
        }
        public Product GetDetailPro(string id)
        {
            return _iproductrepository.GetDetailPro(id);
        }
        public void InsertIntoOrder(Order order)
        {
            _iproductrepository.InsertIntoOrder(order);
        }
    }
}
