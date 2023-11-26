namespace AirTechCodingChallenge.Models;

public record Freight
{
    public required Order Order { get; init; }
    public Flight? Flight { get; init; }

    public override string ToString()
    {
        if (Flight == null)
            return $"order: {Order.OrderNumber}, flightNumber: not scheduled";
        return $"order: {Order.OrderNumber}, flightNumber: {Flight.Number}, departure: {Flight.Departure.Code}, arrival: {Flight.Arrival.Code}, day: {Flight.Day}";
    }
}
