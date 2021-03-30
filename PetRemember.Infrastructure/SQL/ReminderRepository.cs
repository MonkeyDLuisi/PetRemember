using System;
using System.Collections.Generic;
using System.Text;
using PetRemember.Domain.Reminders;

namespace PetRemember.Infrastructure.SQL
{
    public class ReminderRepository : IReminderRepository
    {
        public void Add(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public Reminder Get(Guid id)
        {
            return new Reminder() { Title = "Mockeado maxi" };
        }

        public IEnumerable<Reminder> GetByPet(Guid id)
        {
            var reminders = new List<Reminder>();
            reminders.Add(new Reminder() { Title = "Mockeado maxi" });
            reminders.Add(new Reminder() { Title = "Mockeado mini" });
            return reminders;
        }

        public IEnumerable<Reminder> GetByUser(Guid id)
        {
            throw new NotImplementedException();
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
