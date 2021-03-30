using PetRemember.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetRemember.Application
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid Add(User user)
        {
            return _userRepository.Add(user);
        }

        public Guid? Register(User user, string password)
        {
            user.Salt = Hmac.GenerateSalt();
            user.Password = Hmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(password), user.Salt);
            return _userRepository.Add(user);
        }

        public Guid? Login(string mail, string password)
        {
            var dbuser = _userRepository.Get(mail);
            if (dbuser != null && dbuser.Password.SequenceEqual(Hmac.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(password), dbuser.Salt)))
            {
                return dbuser.Id;
            }
            else
            {
                return null;
            }
        }

        public User Get(string mail)
        {
            return _userRepository.Get(mail);
        }

        public User Get(Guid id)
        {
            return _userRepository.Get(id);
        }

        public void Remove(Guid id)
        {
            _userRepository.Remove(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
