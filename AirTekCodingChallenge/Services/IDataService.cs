using AirTekCodingChallenge.Models;

namespace AirTekCodingChallenge.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Flight>> LoadFlightsAsync();
        Task<IEnumerable<Freight>> LoadFreightsAsync();
    }
}