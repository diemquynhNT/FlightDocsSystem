using DocumentService.Data;
using DocumentService.Model;

namespace DocumentService.Services
{
    public class FlightService : IFlight
    {
        private readonly MyDBContext _context;
        private GenerateRandomId random;


        public FlightService(MyDBContext context) {
            _context = context;
            random = new GenerateRandomId();
        }

        public async Task<Flight> AddFlight(Flight flight)
        {
            string randomId = random.Generate(5);
            flight.IdFlight = "Flight-" +randomId ;
            flight.StatusFlight = true;
            _context.Add(flight);
            _context.SaveChanges();
            return flight;
        }

        public async Task<bool> DeleteFlight(string id)
        {
            var flight = _context.flights.SingleOrDefault(t => t.IdFlight == id);
            if(flight != null)
            {
                _context.Remove(flight);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public List<Flight> GetAllFlight()
        {
            return _context.flights.ToList();
        }

        public async Task<Flight> GetFlightById(string id)
        {
            return _context.flights.Where(t=>t.IdFlight==id).FirstOrDefault();
        }

        public async Task<Flight> UpdateFlight(Flight flight, string idFlight)
        {
            _context.flights.Update(flight);
            _context.SaveChanges();
            return flight;
        }
    }
}
