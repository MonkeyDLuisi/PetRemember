using PetRemember.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string FullName { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
