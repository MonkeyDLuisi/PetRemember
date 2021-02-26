using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PetRemember.Models
{
    public class UserWithPetsViewModel
    {
        public User User { get; set; }
        public List<Pet> Pets {get;set;}
    }
}
