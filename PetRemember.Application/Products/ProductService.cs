using PetRemember.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Application.Products
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public Product Get(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Remove(Guid id)
        {
            _productRepository.Remove(id);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
