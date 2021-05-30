using PetRemember.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace PetRemember.Infrastructure.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlConnection _sqlConnection;
        public ProductRepository()
        {
            _sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=PetRemember;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(Guid id)
        {
            var product = _sqlConnection.QueryFirst<Product>("select * from Products where Id = @id", new { id = id });
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _sqlConnection.Query<Product>("select * from Products");
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
