using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetRemember.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Apellidos")]
        public string Surname { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }


        [NotMapped]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string TextPassword { get; set; }
    }
}
