using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Reminders
{
    public interface IReminderRepository
    {
        Reminder Get(Guid id);
        IEnumerable<Reminder> GetByUser(Guid id);
        IEnumerable<Reminder> GetByPet(Guid id);
        void Add(Reminder reminder);
        void Update(Reminder reminder);
        void Remove(Guid id);
    }
}
