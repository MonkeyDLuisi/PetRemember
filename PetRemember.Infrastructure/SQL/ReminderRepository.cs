using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using PetRemember.Domain.Reminders;

namespace PetRemember.Infrastructure.SQL
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly SqlConnection _sqlConnection;
        public ReminderRepository()
        {
            _sqlConnection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=PetRemember;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public void Add(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public Reminder Get(Guid id)
        {
            var reminder = _sqlConnection.QueryFirst<Reminder>("select * from Reminders where Id = @id", new { id = id });
            return reminder;
        }

        public IEnumerable<Reminder> GetByPet(Guid id)
        {
            var reminders = _sqlConnection.Query<Reminder>("select * from Reminders where PetId = @petId", new { petId = id });
            return reminders;
        }

        public IEnumerable<Reminder> GetByUser(Guid id)
        {
            var reminders = _sqlConnection.Query<Reminder>("select r.* from Reminders r inner join pets p on r.PetId = p.Id where p.UserId = @userId", new { userId = id });
            return reminders;
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reminder reminder)
        {
            throw new NotImplementedException();
        }
    }
}
