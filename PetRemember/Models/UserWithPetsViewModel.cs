using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PetRemember.Models
{
    public class UserWithPetsViewModel
    {
        public User User { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
