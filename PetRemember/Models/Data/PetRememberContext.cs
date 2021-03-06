using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetRemember.Models;

namespace PetRemember.Data
{
    public class PetRememberContext : DbContext
    {
        public PetRememberContext(DbContextOptions<PetRememberContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<PetRemember.Models.Pet> Pet { get; set; }
        public User LoggedUser { get; set; }
    }
}
