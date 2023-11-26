namespace AirTechCodingChallenge.Models;

public record Flight
{
    public required string Number { get; init; }
    public required Plane Plane { get; init; }
    public required Airport Departure { get; init; }
    public required Airport Arrival { get; init; }
    public required int Day { get; init; }
    public List<Order> Orders { get; } = new List<Order>();

    public override string ToString()
    {
        return $"Flight: {Number}, departure: {Departure.Code}, arrival: {Arrival.Code}, day: {Day}";
    }
}
