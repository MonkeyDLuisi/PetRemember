using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Users
{
    public interface IUserRepository
    {
        User Get(string mail);
        User Get(Guid id);
        Guid Add(User user);
        void Update(User user);
        void Remove(Guid id);
    }
}
