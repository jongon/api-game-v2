using Api_Game.Configuration;
using Api_Game.Interfaces;
using Api_Game.Models;
using Api_Game.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Game.Services
{
    public class GameService : IGameService
    {
        public GameApiSettings Settings { get; }

        public GameService(GameApiSettings gameApiSettings)
        {
            Settings = gameApiSettings;
        }

        public async Task<VideoGame> GetGameByIdAsync(long gameId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", "*" }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Games"]}/{gameId}/";
            var result = GameHttpClient.GetAsync<VideoGame>(uri, Settings.Headers, parameters);

            var videoGame = (await result).FirstOrDefault();

            var developersIds = JsonConvert.DeserializeObject<IEnumerable<long>>(JsonConvert.SerializeObject(videoGame.Developers));
            var publisherIds = JsonConvert.DeserializeObject<IEnumerable<long>>(JsonConvert.SerializeObject(videoGame.Publishers));

            var developers = GetDevelopersAsync(developersIds);
            var publishers = GetPublishersAsync(publisherIds);

            videoGame.Publishers = await publishers;
            videoGame.Developers = await developers;

            return videoGame;
        }

        public async Task<IEnumerable<VideoGameName>> GetGamesAsync(string term)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", "name" },
                { "search", term }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Games"]}/";
            var result = await GameHttpClient.GetAsync<VideoGameName>(uri, Settings.Headers, parameters);
            return result;
        }

        public async Task<Company> GetPublisherByIdAsync(long publisherId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", "*" }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Publishers"]}/{publisherId}/";
            var result = GameHttpClient.GetAsync<Company>(uri, Settings.Headers, parameters);
            return (await result).FirstOrDefault();
        }

        public async Task<Company> GetDeveloperByIdAsync(long developerId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", "*" }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Developers"]}/{developerId}/";
            var result = GameHttpClient.GetAsync<Company>(uri, Settings.Headers, parameters);
            return (await result).FirstOrDefault();
        }

        public async Task<IEnumerable<Company>> GetDevelopersAsync(IEnumerable<long> developerIds)
        {
            var tasks = developerIds.Select(GetDeveloperByIdAsync).ToList();

            var developers = new List<Company>();
            foreach (var task in tasks)
            {
                developers.Add(await task);
            }

            return developers;
        }

        public async Task<IEnumerable<Company>> GetPublishersAsync(IEnumerable<long> publisherIds)
        {
            var tasks = publisherIds.Select(GetPublisherByIdAsync).ToList();

            var publishers = new List<Company>();
            foreach (var task in tasks)
            {
                publishers.Add(await task);
            }

            return publishers;
        }
    }
}