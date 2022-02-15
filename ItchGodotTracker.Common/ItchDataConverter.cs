using Newtonsoft.Json;

namespace ItchGodotTracker.Common
{
    public static class ItchService
    {
        internal const string File = @"https://raw.githubusercontent.com/Godotes/itchGodotGames/main/TotalClean.json";

        public static IList<ItchGame> GetGodotGames()
        {
            using HttpClient? client = new();

            return Task.Run(() => client.GetStringAsync(File))
                .Result
                .DeserializeFromJson()
                .ConvertJsonsToCustomObjects()
                .ToList();
        }

        internal static IList<ItchGameMediatorClass> DeserializeFromJson(this string jsonContent)
        {
            var result = JsonConvert.DeserializeObject<IList<ItchGameMediatorClass>>(jsonContent);

            if (result == null)
                return new List<ItchGameMediatorClass>();

            return result;
        }

        internal static IList<ItchGame> ConvertJsonsToCustomObjects(
            this IList<ItchGameMediatorClass> simpleObjects)
        {
            var builder = new ItchGameItemBuilder();

            return simpleObjects.Select(x => builder.Create(x)).ToList();
        }
    }
}
