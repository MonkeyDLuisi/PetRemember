using PetRemember.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace PetRemember.Infrastructure.SQL
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _sqlConnection;
        public UserRepository()
        {
            _sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=PetRememberContext-1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public Guid Add(User user)
        {
            var userId = _sqlConnection.ExecuteScalar("insert into Users (Mail, Password, Salt, FullName) output inserted.Id values (@Mail, @Password, @Salt, @FullName)", new { Mail = user.Mail, Password = user.Password, Salt = user.Salt, FullName = user.FullName });
            return (Guid)userId;
        }

        public User Get(string mail)
        {
            var user = _sqlConnection.QueryFirst<User>("select * from Users where Mail = @mail", new { mail = mail });
            return user;            
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
