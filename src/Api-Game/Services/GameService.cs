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
        private readonly GameApiSettings _gameApiSettings;

        public GameService(GameApiSettings gameApiSettings)
        {
            _gameApiSettings = gameApiSettings;
        }

        public async Task<VideoGame> GetGameByIdAsync(long id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "id", id.ToString() }
            };
            var uri = _gameApiSettings.ApiUri + "/" + _gameApiSettings.GamePath;
            return GameHttpClient.GetAsync<VideoGame>(uri, _gameApiSettings.ApiKey, parameters).Result;
        }

        public async Task<IEnumerable<VideoGame>> GetGamesAsync(string term)
        {
            throw new NotImplementedException();
        }
    }
}
