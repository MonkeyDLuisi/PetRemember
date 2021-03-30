using PetRemember.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Infrastructure.SQL
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(Guid id)
        {
            return new Product() { Class = "Mockeado maxi", MinWeight = 8 };
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            products.Add(new Product() { Name = "Mockeado maxi", MinWeight = 8 });
            products.Add(new Product() { Name = "Mockeado mini", MaxWeight = 8 });
            return products;
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
