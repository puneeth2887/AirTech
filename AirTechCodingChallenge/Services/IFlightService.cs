using AirTechCodingChallenge.Models;

namespace AirTechCodingChallenge.Services
{
    public interface IFlightService
    {
        Task<Flight> CreateFlightAsync(string name, Airport departure, Airport arrival, Plane plane, int day);
    }
}