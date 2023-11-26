using AirTechCodingChallenge.Models;

namespace AirTechCodingChallenge.Services;

public class AirportService : IAirportService
{
    public async Task<Airport> CreateAirportAsync(string code, string name)
    {
        return await Task.Run(() =>
        {
            return new Airport { Code = code, Name = name };
        });
    }
}
