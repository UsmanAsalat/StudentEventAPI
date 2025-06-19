namespace StudentEventAPI.Models
{
    public class Registration
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
