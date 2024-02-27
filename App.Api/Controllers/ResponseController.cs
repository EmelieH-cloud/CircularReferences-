using Database.DbConnection;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace App.Api.Controllers
{
    public class ResponseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly GenericRepo<ResponseModel> _responseRepo;

        public ResponseController(AppDbContext context, GenericRepo<ResponseModel> responseRepo)
        {
            _context = context;
            _responseRepo = responseRepo;
        }


        [HttpGet("Responses")]
        public ActionResult<List<ResponseModel>> GetAllResponses()
        {
            var tickets = _responseRepo.GetAll();

            return Ok(tickets);
        }


        [HttpPost("Responses")]
        public ActionResult PostResponse(ResponseModel newTicket)
        {
            if (newTicket != null)
            {
                _responseRepo.Add(newTicket);

                return Ok();
            }

            return BadRequest();
        }


        [HttpDelete("Response/{id}")]
        public ActionResult DeleteResponse(int id)
        {
            var ticket = _context.Responses.FirstOrDefault(x => x.Id == id);

            if (ticket != null)
            {
                _responseRepo.Delete(id);
                return Ok(ticket);
            }


            return NoContent();
        }
    }
}
