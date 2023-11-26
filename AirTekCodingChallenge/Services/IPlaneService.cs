using AirTekCodingChallenge.Models;

namespace AirTekCodingChallenge.Services
{
    public interface IPlaneService
    {
        Task<Plane> CreatePlaneAsync(string name, int capacity = 20);
    }
}