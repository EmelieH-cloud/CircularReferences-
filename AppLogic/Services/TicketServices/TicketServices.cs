using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;


namespace AppLogic.Services.TicketServices
{
    public class TicketServices : ITicketServices
    { // Klass som gör HTTP-anrop till API:et och försöker returnera en API-modell efter deserialiseringen. 
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7249/api/")
        };



        public async Task<TicketModel> GetTicketById(int id)
        {
            var response = await Client.GetAsync($"Ticket/Ticket/{id}");

            if (response.IsSuccessStatusCode)
            {
                string ticketJson = await response.Content.ReadAsStringAsync();

                TicketModel? ticket = JsonConvert.DeserializeObject<TicketModel>(ticketJson);
                if (ticket != null)
                {
                    return ticket;
                }
                throw new JsonException();
            }

            throw new HttpRequestException($"Error getting ticket with ID: {id}");
        }

        public async Task<List<TicketModel>> GetTickets()
        {
            var response = await Client.GetAsync("Ticket/Tickets");

            if (response.IsSuccessStatusCode)
            {
                string ticketjson = await response.Content.ReadAsStringAsync();

                List<TicketModel>? tickets = JsonConvert.DeserializeObject<List<TicketModel>>(ticketjson);

                if (tickets != null)
                {
                    return tickets;
                }

                throw new JsonException();
            }

            throw new HttpRequestException();
        }


        public async Task PostTicket(TicketModel ticket)
        {
            await Client.PostAsJsonAsync("Ticket/PostTicket", ticket);
        }
    }
}
