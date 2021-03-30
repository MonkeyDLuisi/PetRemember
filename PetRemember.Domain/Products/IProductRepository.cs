using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Products
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Remove(Guid id);
    }
}
