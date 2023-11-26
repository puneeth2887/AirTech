using AirTekCodingChallenge.Models;

namespace AirTekCodingChallenge.Services;

public class PlaneService : IPlaneService
{
    public async Task<Plane> CreatePlaneAsync(string name, int capacity = 20)
    {
        return await Task.Run(() =>
        {
            return new Plane { Name = name, Capacity = capacity };
        });
    }
}
