using AirTechCodingChallenge.Models;

namespace AirTechCodingChallenge.Services
{
    public interface IPlaneService
    {
        Task<Plane> CreatePlaneAsync(string name, int capacity = 20);
    }
}