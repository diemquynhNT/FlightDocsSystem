using FlightDocs_System.Model;
using FlightDocs_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly IAirplane _context;

        public AirplanesController(IAirplane context) {
            _context = context;
        }
        [HttpGet("ListAirplane")]
        public List<Airplane> ListAirplane()
        {
            return _context.GetAllList();

        }

        [HttpGet("GetAirplaneById")]
        public Task<Airplane> GetAirplaneById(string airplaneNo)
        {
            return _context.GetAirplaneById(airplaneNo);

        }

        [HttpPost("AddAirplane")]
        public async Task<ActionResult> AddAirplane([FromBody] Airplane airplane)
        {
            try
            {
                await _context.AddAirplane(airplane);
                return Ok("tao thanh cong");
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("UpdateAirplane")]
        public async Task<IActionResult> UpdateAirplane(string id, [FromBody] Airplane airplane)
        {
            var air = await _context.GetAirplaneById(id);
            if (air == null)
            {
                return NotFound("Khong tim thay air");
            }
            await _context.UpdateAirplane(airplane);
            return Ok(" cap nhat thanh cong");
        }

        [HttpDelete("DeleteAirplane")]
        public async Task<IActionResult> DeleteAirplane(string airNo)
        {
            var result = await _context.DeleteAirplane(airNo);
            if (!result)
                return NotFound();
            return Ok("xoa thanh cong");
        }
    }
}
