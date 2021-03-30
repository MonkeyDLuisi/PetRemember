using PetRemember.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Application
{
    public interface IUserService
    {
        User Get(string mail);
        User Get(Guid uid);
        Guid Add(User user);
        Guid? Register(User user, string password);
        Guid? Login(string mail, string password);
        void Update(User user);
        void Remove(Guid id);
    }
}
