using AirTechCodingChallenge.Models;

namespace AirTechCodingChallenge.Services;

public class FlightService : IFlightService
{
    public async Task<Flight> CreateFlightAsync(string number, Airport departure, Airport arrival, Plane plane, int day)
    {
        return await Task.Run(() =>
        {
            return new Flight { Number = number, Departure = departure, Arrival = arrival, Plane = plane, Day = day };
        });
    }
}
