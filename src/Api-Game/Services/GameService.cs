using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;
using Api_Game.Interfaces;
using Api_Game.Models;
using Api_Game.Utils;

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

            var uri = $"{Settings.ApiUri}/{Settings.Paths["Games"]}/{gameId}";
            var result = await GameHttpClient.GetAsync<VideoGame>(uri, Settings.Headers, parameters);
            return result.FirstOrDefault();
        }

        public Task<IEnumerable<VideoGame>> GetGamesAsync(string term)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetPublisherById(long publisherId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetDeveloperById(long developerId)
        {
            throw new NotImplementedException();
        }
    }
}
