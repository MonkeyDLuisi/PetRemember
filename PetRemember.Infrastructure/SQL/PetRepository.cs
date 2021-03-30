using PetRemember.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Infrastructure.SQL
{
    public class PetRepository : IPetRepository
    {
        public void Add(Pet pet)
        {
            
        }

        public Pet Get(Guid id)
        {
            return new Pet() { Name = "Mockeado maxi", Weight=10 };
        }

        public IEnumerable<Pet> GetByUser(Guid userId)
        {
            var pets = new List<Pet>();
            pets.Add(new Pet() { Name = "Mockeado maxi", Weight=10});
            pets.Add(new Pet() { Name = "Mockeado mini", Weight = 5 });
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
