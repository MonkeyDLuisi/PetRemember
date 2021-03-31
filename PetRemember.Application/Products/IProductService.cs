using PetRemember.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Application.Products
{
    public interface IProductService
    {
        Product Get(Guid id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Remove(Guid id);
    }
}
