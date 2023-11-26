using AirTekCodingChallenge.Services;
using AirTekCodingChallenge.UserStories;
using Microsoft.Extensions.DependencyInjection;

namespace AirTekCodingChallenge.DependencyInjection;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
             .AddSingleton<IUserStory, UserStory1>()
             .AddSingleton<IUserStory, UserStory2>()
             .AddSingleton<IUserStoryFactory, UserStoryFactory>()
             .AddSingleton<IAirportService, AirportService>()
             .AddSingleton<IPlaneService, PlaneService>()
             .AddSingleton<IFlightService, FlightService>()
             .AddSingleton<IDataService, DataService>();
    }
}
