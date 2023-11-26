using AirTechCodingChallenge.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirTechCodingChallenge.Services;

public class DataService : IDataService
{
    private readonly IAirportService airportService;
    private readonly IPlaneService planeService;
    private readonly IFlightService flightService;

    public DataService(IAirportService airportService, IPlaneService planeService, IFlightService flightService)
    {
        this.airportService = airportService;
        this.planeService = planeService;
        this.flightService = flightService;
    }

    /// <summary>
    /// Loading hard coded Flight details. This is what I understood from the code challenge.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Flight>> LoadFlightsAsync()
    {
        // hard coded data

        // airports
        var montreal = await airportService.CreateAirportAsync("YUL", "Montreal");
        var toronto = await airportService.CreateAirportAsync("YYZ", "Toronto");
        var calgary = await airportService.CreateAirportAsync("YYC", "Calgary");
        var vancouver = await airportService.CreateAirportAsync("YVR", "Vancouver");
        var fortNelson = await airportService.CreateAirportAsync("YYE", "Fort Nelson");

        // planes
        var plane1 = await planeService.CreatePlaneAsync("1", 20);
        var plane2 = await planeService.CreatePlaneAsync("2", 20);
        var plane3 = await planeService.CreatePlaneAsync("3", 20);

        return new[]
        {
            await flightService.CreateFlightAsync("1", montreal, toronto, plane1, 1),
            await flightService.CreateFlightAsync("2", montreal, calgary, plane2, 1),
            await flightService.CreateFlightAsync("3", montreal, vancouver, plane3, 1),
            await flightService.CreateFlightAsync("4", montreal, toronto, plane1, 2),
            await flightService.CreateFlightAsync("5", montreal, calgary, plane2, 2),
            await flightService.CreateFlightAsync("6", montreal, vancouver, plane3, 2),
        };
    }

    public async Task<IEnumerable<Freight>> LoadFreightsAsync()
    {
        var flights = await LoadFlightsAsync();
        var orders = await LoadOrdersAsync();
        var freights = new List<Freight>();

        var GetNextAvailableFlights = (Order order) =>
        {
            var allDestFlights = flights.Where(p => p.Arrival.Code == order.Destination).OrderBy(p => p.Day);
            foreach (var item in allDestFlights)
            {
                if (item.Orders.Count < item.Plane.Capacity)
                    return item;
            }
            return null;
        };

        foreach (var order in orders)
        {
            var flight = GetNextAvailableFlights(order);
            flight?.Orders.Add(order);

            freights.Add(new Freight
            {
                Order = order,
                Flight = flight
            });
        }

        return freights;
    }

    /// <summary>
    /// Load orders from the json file
    /// </summary>
    /// <returns></returns>
    private async Task<IEnumerable<Order>> LoadOrdersAsync()
    {
        var jsonOrder = await File.ReadAllTextAsync("coding-assigment-orders.json");
        var orders = JObject.Parse(jsonOrder);
        return orders.Properties()
            .Select(p => new Order { OrderNumber = p.Name, Destination = (p.Value as JObject).Properties().First().Value.ToString() });
    }
}
