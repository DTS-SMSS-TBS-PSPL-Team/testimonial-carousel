using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TS.Data;
using TS.Models;

namespace TS.Controllers
{
    public class RegisteredUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisteredUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RegisteredUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredUser>>> GetRegisteredUsers()
        {
            return await _context.RegisteredUsers.ToListAsync();
        }

        // GET: api/RegisteredUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredUser>> GetRegisteredUser(int id)
        {
            var registeredUser = await _context.RegisteredUsers.FindAsync(id);

            if (registeredUser == null)
            {
                return NotFound();
            }

            return registeredUser;
        }

        // PUT: api/RegisteredUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisteredUser(int id, RegisteredUser registeredUser)
        {
            if (id != registeredUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(registeredUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisteredUserExists(id))
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

        // POST: api/RegisteredUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisteredUser>> PostRegisteredUser(RegisteredUser registeredUser)
        {
            _context.RegisteredUsers.Add(registeredUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisteredUser", new { id = registeredUser.Id }, registeredUser);
        }

        // DELETE: api/RegisteredUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteredUser(int id)
        {
            var registeredUser = await _context.RegisteredUsers.FindAsync(id);
            if (registeredUser == null)
            {
                return NotFound();
            }

            _context.RegisteredUsers.Remove(registeredUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegisteredUserExists(int id)
        {
            return _context.RegisteredUsers.Any(e => e.Id == id);
        }
    }
}

