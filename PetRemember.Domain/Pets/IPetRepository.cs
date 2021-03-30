using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Pets
{
    public interface IPetRepository
    {
        Pet Get(Guid id);
        IEnumerable<Pet> GetByUser(Guid userId);
        void Add(Pet pet);
        void Update(Pet pet);
        void Remove(Guid id);
        void RemoveAll(Guid id);
    }
}
