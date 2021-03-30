using PetRemember.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PetRemember.Infrastructure.SQL
{
    public class UserRepository : IUserRepository
    {
        public Guid Add(User user)
        {
            return Guid.NewGuid();
        }

        public User Get(string mail)
        {
            var salt = Hmac.GenerateSalt();
            return new User() { FullName = "Mockeado", Id = Guid.NewGuid(), Salt = salt, Password = Hmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes("test"), salt) };            
        }

        public User Get(Guid id)
        {
            return new User() { FullName = "Mockeado", Id = id };
        }

        public void Remove(Guid id)
        {
            
        }

        public void Update(User user)
        {
            
        }
    }
}
