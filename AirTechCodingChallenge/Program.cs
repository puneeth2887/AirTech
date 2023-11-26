using AirTechCodingChallenge.DependencyInjection;
using AirTechCodingChallenge.UserStories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddServices();

using var host = builder.Build();
//await host.RunAsync();

var userStoryFactory = host.Services.GetService<IUserStoryFactory>();

if (userStoryFactory == null)
    throw new Exception("Not Found");


while (true)
{
    await Console.Out.WriteLineAsync("Select user story 1 or 2.");
    await Console.Out.WriteLineAsync("0 to close");
    var option = await Console.In.ReadLineAsync();

    if (option == "0")
        break;

    if (!Enum.TryParse<UserStoryType>(option, out var type))
    {
        await Console.Out.WriteLineAsync("Invalid Option");
        continue;
    }

    var story = userStoryFactory.CreateUserStory(type);

    await story.ExecuteAsync();
    await Console.Out.WriteLineAsync();
    await Console.Out.WriteLineAsync();
}