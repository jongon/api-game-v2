using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;
using Api_Game.Models;

namespace Api_Game.Interfaces
{
    public interface IGameService
    {
        GameApiSettings Settings { get; }

        Task<VideoGame> GetGameByIdAsync(long gameId);

        Task<IEnumerable<VideoGame>> GetGamesAsync(string term);

        Task<Company> GetPublisherById(long publisherId);

        Task<Company> GetDeveloperById(long developerId);
    }
}
