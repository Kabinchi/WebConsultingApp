using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebConsulting.Models;

namespace WebConsulting.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ConsultingDBContext _context;

        public UsersController(ConsultingDBContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, User user)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
