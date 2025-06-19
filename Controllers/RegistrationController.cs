using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEventAPI.Data;
using StudentEventAPI.Models;

namespace StudentEventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/registration?studentId=1&eventId=1
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(int studentId, int eventId)
        {
            var existing = await _context.Registrations
                .FirstOrDefaultAsync(r => r.StudentId == studentId && r.EventId == eventId);

            if (existing != null)
                return BadRequest("Student is already registered for this event.");

            var ev = await _context.Events.FindAsync(eventId);
            if (ev == null)
                return NotFound("Event not found.");

            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                student = new Student { Name = $"Student {studentId}" };
                _context.Students.Add(student);
                await _context.SaveChangesAsync(); // Let DB generate ID
            }

            var registration = new Registration
            {
                StudentId = student.Id,
                EventId = eventId
            };

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return Ok("Student registered successfully.");
        }

        // GET: api/registration/event/1
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetRegisteredStudents(int eventId)
        {
            var students = await _context.Registrations
                .Where(r => r.EventId == eventId)
                .Select(r => r.Student)
                .ToListAsync();

            return students;
        }
    }
}
