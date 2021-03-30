using PetRemember.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Application
{
    public class PetService : IPetService
    {
        public readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public void Add(Pet pet)
        {
            _petRepository.Add(pet);
        }

        public Pet Get(Guid id)
        {
            return _petRepository.Get(id);
        }

        public IEnumerable<Pet> GetByUser(Guid userId)
        {
            return _petRepository.GetByUser(userId);
        }

        public void Remove(Guid id)
        {
            _petRepository.Remove(id);
        }

        public void RemoveAll(Guid id)
        {
            _petRepository.RemoveAll(id);
        }

        public void Update(Pet pet)
        {
            _petRepository.Update(pet);
        }
    }
}
