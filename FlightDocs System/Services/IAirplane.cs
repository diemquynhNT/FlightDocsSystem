using FlightDocs_System.Model;

namespace FlightDocs_System.Services
{
    public interface IAirplane
    {
        public List<Airplane> GetAllList();
        public Task<Airplane> AddAirplane(Airplane airplane);
        public Task<Airplane> UpdateAirplane(Airplane airplane);
        public Task<bool> DeleteAirplane(string id);
        public Task<Airplane> GetAirplaneById(string id);
    }
}
