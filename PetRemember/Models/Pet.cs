using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetRemember.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Edad")]
        public int Age { get; set; }
        [Display(Name = "Peso")]
        public int Weight { get; set; }
        public string Animal { get; set; }
        public string Breed { get; set; }
        [Display(Name = "Raza")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
