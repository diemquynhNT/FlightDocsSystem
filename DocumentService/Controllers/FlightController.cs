using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;
using DocumentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlight _context;
        private readonly IMapper _mapper;

        public FlightController(IFlight context,IMapper mapper) {
            _context = context;
            _mapper = mapper;
        
        }

        [HttpGet("ListAllFlight")]
        public List<Flight> ListAllFlight()
        {
            return _context.GetAllFlight();

        }
        [HttpGet("GetDetail")]
        public Task<Flight> GetFlightById(string idFlight)
        {
            return _context.GetFlightById(idFlight);

        }

        [HttpPost("AddFlight")]
        public async Task<ActionResult> AddFlight([FromForm] FlightModel fl)
        {
            try
            {
                var flight = _mapper.Map<Flight>(fl);
                await _context.AddFlight(flight);
                return Ok("tao thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateFlight")]
        public async Task<IActionResult> UpdateFlight(string id, [FromForm] Flight flight)
        {
            var fl = await _context.GetFlightById(id);
            if (fl == null)
            {
                return NotFound("Khong tim thay air");
            }
            await _context.UpdateFlight(flight,id);
            return Ok(" cap nhat thanh cong");
        }


        [HttpDelete("DeleteFlight")]
        public async Task<ActionResult> DeleteFlight(string idFlight)
        {
            try
            {
                bool flight= await _context.DeleteFlight(idFlight);
                if(flight==true)
                    return Ok("xoa thanh cong");
                return BadRequest("loi");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
