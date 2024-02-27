using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Database.DbConnection
{
    public class TicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        // Hämta alla taggar för en specifik ticket med hjälp av include
        public List<TagModel> GetTagsForTicket(int ticketId)
        {
            return _context.TicketTag
                .Where(tt => tt.TicketId == ticketId)
                .Include(tt => tt.Tag)
                .Select(tt => tt.Tag)
                .ToList();
        }

    }

}