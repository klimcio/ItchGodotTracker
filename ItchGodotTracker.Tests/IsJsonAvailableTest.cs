using FluentAssertions;
using ItchGodotTracker.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ItchGodotTracker.Tests
{
    public class IsJsonAvailableTest
    {
        private const string File = @"https://raw.githubusercontent.com/Godotes/itchGodotGames/main/TotalClean.json";

        [Fact]
        public void IsJsonAvailable()
        {
            using HttpClient? client = new();
            
            var fileContent = Task.Run(() => client.GetStringAsync(File)).Result;

            fileContent.Should().NotBeEmpty();
        }

        [Fact]
        public void DoesItParseWithoutProblems()
        {
            using HttpClient? client = new();

            var json = Task.Run(() => client.GetStringAsync(File)).Result;

            var result = JsonConvert.DeserializeObject<IList<ItchGame>>(json);

            result.Count.Should().NotBe(0);
        }
    }
}