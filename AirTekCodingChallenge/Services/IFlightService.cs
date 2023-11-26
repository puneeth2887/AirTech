using AirTekCodingChallenge.Models;

namespace AirTekCodingChallenge.Services
{
    public interface IFlightService
    {
        Task<Flight> CreateFlightAsync(string name, Airport departure, Airport arrival, Plane plane, int day);
    }
}