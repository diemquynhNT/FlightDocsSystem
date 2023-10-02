using DocumentService.Model;

namespace DocumentService.Services
{
    public interface IFlight
    {
        public List<Flight> GetAllFlight();
        public Task<Flight> GetFlightById(string id);
        public Task<Flight> AddFlight(Flight flight);
        public Task<Flight> UpdateFlight(Flight flight,string idFlight);
        public Task<bool> DeleteFlight(string id);
      
    }
}
