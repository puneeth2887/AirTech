using AirTechCodingChallenge.Models;

namespace AirTechCodingChallenge.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Flight>> LoadFlightsAsync();
        Task<IEnumerable<Freight>> LoadFreightsAsync();
    }
}