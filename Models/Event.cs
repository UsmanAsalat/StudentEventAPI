using System;
using System.Collections.Generic;

namespace StudentEventAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Registration>? Registrations { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}

