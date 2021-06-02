using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    //[JwtAuthorize]
    [Authorize]

    public class TicketsController : ControllerBase
    {
        private readonly BugsDBContext Db;
        public TicketsController(BugsDBContext db)
        {
            this.Db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Db.Tickets.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await Db.Tickets.FindAsync(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ticket  ticket)
        {
            Db.Tickets.Add(ticket);
            await Db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                    new { id = ticket.TicketId },
                    ticket
                );
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();

            Db.Entry(ticket).State = EntityState.Modified;

            try
            {
                await Db.SaveChangesAsync();
            }
            catch
            {
                if (await Db.Tickets.FindAsync(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await Db.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            Db.Tickets.Remove(ticket);
            await Db.SaveChangesAsync();

            return Ok(ticket);
        }
    }
}
