using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ItchGodotTracker.Tests
{
    public class IsJsonAvailableTest
    {
        [Fact]
        public void IsJsonAvailable()
        {
            var file = @"https://raw.githubusercontent.com/Godotes/itchGodotGames/main/TotalClean.json";

            using HttpClient? client = new();
            
            var fileContent = Task.Run(() => client.GetStringAsync(file)).Result;

            fileContent.Should().NotBeEmpty();
        }
    }
}