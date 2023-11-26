using AirTekCodingChallenge.Services;

namespace AirTekCodingChallenge.UserStories;

public class UserStory1 : IUserStory
{
    private readonly IDataService dataService;

    public UserStoryType AppliesTo => UserStoryType.Type1;

    public UserStory1(IDataService dataService)
    {
        this.dataService = dataService;
    }

    public async Task ExecuteAsync()
    {
        var flights = await dataService.LoadFlightsAsync();
        foreach (var flight in flights)
        {
            Console.WriteLine(flight);
        }
    }
}
