using PetRemember.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace PetRemember.Infrastructure.SQL
{
    public class PetRepository : IPetRepository
    {
        private readonly SqlConnection _sqlConnection;
        public PetRepository()
        {
            _sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=PetRemember;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public void Add(Pet pet)
        {
             _sqlConnection.ExecuteScalar("insert into Pets (UserId, Name, BornDate, Weight, Animal, Breed) values (@UserId, @Name, @BornDate, @Weight, @Animal, @Breed)", new { UserId = pet.UserId, Name = pet.Name, BornDate = pet.BornDate, Weight = pet.Weight, Animal = pet.Animal, Breed = pet.Breed });
        }

        public Pet Get(Guid id)
        {
            var pet = _sqlConnection.QueryFirst<Pet>("select * from Pets where Id = @id", new { id = id });
            return pet;
        }

        public IEnumerable<Pet> GetByUser(Guid userId)
        {
            var pets = _sqlConnection.Query<Pet>("select * from Pets where UserId = @userId", new { userId = userId });
            return pets;
        }

        public void Remove(Guid id)
        {
            
        }

        public void RemoveAll(Guid id)
        {
            
        }

        public void Update(Pet pet)
        {
            
        }
    }
}
