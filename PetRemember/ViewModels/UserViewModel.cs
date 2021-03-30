using PetRemember.Domain.Pets;
using PetRemember.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRemember.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
        public string Password { get; set; }
    }
}
