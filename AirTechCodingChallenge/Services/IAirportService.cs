using AirTechCodingChallenge.Models;

namespace AirTechCodingChallenge.Services
{
    public interface IAirportService
    {
        Task<Airport> CreateAirportAsync(string code, string name);
    }
}