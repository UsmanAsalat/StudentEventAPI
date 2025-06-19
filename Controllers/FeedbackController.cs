using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEventAPI.Data;
using StudentEventAPI.Models;

namespace StudentEventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/feedback
        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(int eventId, int rating, string comment)
        {
            var ev = await _context.Events.FindAsync(eventId);
            if (ev == null)
                return NotFound("Event not found.");

            if (ev.Date > DateTime.Now)
                return BadRequest("Feedback can only be submitted after the event date.");

            var feedback = new Feedback
            {
                EventId = eventId,
                Rating = rating,
                Comment = comment,
                SubmittedAt = DateTime.Now
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok("Feedback submitted successfully.");
        }

        // GET: api/feedback/event/1
        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacksForEvent(int eventId)
        {
            return await _context.Feedbacks
                .Where(f => f.EventId == eventId)
                .ToListAsync();
        }
    }
}
