namespace AirTekCodingChallenge.UserStories
{
    public interface IUserStory
    {
        UserStoryType AppliesTo { get; }

        Task ExecuteAsync();
    }
}