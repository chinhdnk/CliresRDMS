using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ITicketsScreenUseCases
    {
        Task<int> AddTicket(Ticket ticket);
        Task DeleteTicket(int ticketId);
        Task<IEnumerable<Ticket>> SearchTickets(string filter);
        Task UpdateTicket(Ticket ticket);
        Task<IEnumerable<Ticket>> ViewOwnersTickets(int projectId, string ownerName);
        Task<Ticket> ViewTicketById(int ticketId);
        Task<IEnumerable<Ticket>> ViewTickets(int projectId);
    }
}