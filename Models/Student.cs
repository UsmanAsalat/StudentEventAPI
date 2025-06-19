using System.Collections.Generic;

namespace StudentEventAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
