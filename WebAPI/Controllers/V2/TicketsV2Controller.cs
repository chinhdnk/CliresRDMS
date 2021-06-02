using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using WebAPI.Filters.V2;
using WebAPI.QueryFilters;

namespace WebAPI.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/tickets")]
    [JwtAuthorize]
    public class TicketsV2Controller : ControllerBase
    {
        private readonly BugsDBContext Db;
        public TicketsV2Controller(BugsDBContext db)
        {
            this.Db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TicketQueryFilter ticketQueryFilter)
        {
            IQueryable<Ticket> tickets = Db.Tickets;

            if (ticketQueryFilter != null)
            {
                if (ticketQueryFilter.Id.HasValue)
                    tickets = tickets.Where(x => x.TicketId == ticketQueryFilter.Id);

                if (!string.IsNullOrWhiteSpace(ticketQueryFilter.TitleOrDescription))
                    tickets = tickets.Where(x => x.Title.Contains(ticketQueryFilter.TitleOrDescription,
                       StringComparison.OrdinalIgnoreCase) ||
                       x.Description.Contains(ticketQueryFilter.TitleOrDescription,
                       StringComparison.OrdinalIgnoreCase));
            }


            return Ok(await tickets.ToListAsync());
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
        [Ticket_EnsureDescriptionPresentActionFilter]
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
