using Database.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        // API:ets "hjärna" som tar emot olika requests och mappar dem gentemot namnen nedan. 
        // Controllern har ingen direktkontakt med databasen utan använder sig av repositories.

        private readonly AppDbContext _context;
        private readonly GenericRepo<TicketModel> _ticketRepo;
        private readonly TicketRepository _ticketRepository;

        public TicketController(AppDbContext context, GenericRepo<TicketModel> ticketRepo, TicketRepository ticketRepository)
        {
            _context = context;
            _ticketRepo = ticketRepo;
            _ticketRepository = ticketRepository;
        }

        [HttpGet("Ticket/{id}")]
        public ActionResult<TicketModel> GetTicketById(int id)
        {
            var ticket = _ticketRepo.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpGet("Tickets")]
        public ActionResult<List<TicketModel>> GetTickets()
        {
            var tickets = _ticketRepo.GetAll();
            return Ok(tickets);
        }



        [HttpPost("PostTicket")]
        public ActionResult PostTicket(TicketModel ticket)
        {
            if (ticket != null)
            {
                _ticketRepo.Add(ticket);
                return Ok();
            }

            return BadRequest();
        }


        [HttpDelete("Ticket/{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == id);

            if (ticket != null)
            {
                _ticketRepo.Delete(id);
                return Ok(ticket);
            }

            return NoContent();
        }

        [HttpGet("TicketTags/{ticketId}")]
        public ActionResult<List<TagModel>> GetTagsForTicket(int ticketId)
        {
            var tagsForTicket = _ticketRepository.GetTagsForTicket(ticketId); // Använd TicketRepository för att hämta taggar för ticket

            return Ok(tagsForTicket);
        }


    }
}
