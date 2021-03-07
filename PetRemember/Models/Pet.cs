using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRemember.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Animal { get; set; }
        public string Breed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
