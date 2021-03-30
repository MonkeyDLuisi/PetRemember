using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Pets
{
    public class Pet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
        public int Weight { get; set; }
        public string Animal { get; set; }
        public string Breed { get; set; }
    }
}
