using Shared.Models;


namespace AppLogic.Services.TicketServices
{
    public interface ITicketServices
    {
        public HttpClient Client { get; set; }

        public Task<List<TicketModel>> GetTickets();

        public Task<TicketModel> GetTicketById(int id);

        public Task PostTicket(TicketModel ticket);
    }
}
