using FlightDocs_System.Data;
using FlightDocs_System.Model;

namespace FlightDocs_System.Services
{
    public class AirplaneServices : IAirplane
    {
        private readonly MyDBContext _dbContext;

        public AirplaneServices(MyDBContext dBContext) { 
            _dbContext=dBContext;
            
        }

        public async Task<Airplane> AddAirplane(Airplane airplane)
        {
            _dbContext.Add(airplane);
            _dbContext.SaveChanges();
            return airplane;
        }

        public async Task<bool> DeleteAirplane(string id)
        {
            var air = _dbContext.airplanes.SingleOrDefault(t => t.AirplaneNo == id);
            if(air != null)
            {
                _dbContext.Remove(air);
                _dbContext.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<Airplane> GetAirplaneById(string id)
        {
            return _dbContext.airplanes.Where(t=>t.AirplaneNo==id).FirstOrDefault();
        }

        public List<Airplane> GetAllList()
        {
            return _dbContext.airplanes.ToList();
        }

        public async Task<Airplane> UpdateAirplane(Airplane airplane)
        {
            _dbContext.airplanes.Update(airplane);
            _dbContext.SaveChanges();
            return airplane;
        }
    }
}
