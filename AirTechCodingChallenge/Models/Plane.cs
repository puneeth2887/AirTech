namespace AirTechCodingChallenge.Models;

public record Plane
{
    public required string Name { get; init; }
    public required int Capacity { get; init; }
}
