using PetRemember.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Application
{
    public interface IPetService
    {
        Pet Get(Guid id);
        IEnumerable<Pet> GetByUser(Guid userId);
        void Add(Pet pet);
        void Update(Pet pet);
        void Remove(Guid id);
        void RemoveAll(Guid id);
    }
}
