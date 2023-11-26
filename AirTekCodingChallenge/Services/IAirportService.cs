using AirTekCodingChallenge.Models;

namespace AirTekCodingChallenge.Services
{
    public interface IAirportService
    {
        Task<Airport> CreateAirportAsync(string code, string name);
    }
}