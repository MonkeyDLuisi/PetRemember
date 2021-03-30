using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Reminders
{
    public class Reminder
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PetId { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
