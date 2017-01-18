using Api_Game.Configuration;
using Api_Game.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Game.Interfaces
{
    public interface IGameService
    {
        GameApiSettings Settings { get; }

        Task<VideoGame> GetGameByIdAsync(long gameId);

        Task<IEnumerable<VideoGameName>> GetGamesAsync(string term);

        Task<Company> GetPublisherByIdAsync(long publisherId);

        Task<Company> GetDeveloperByIdAsync(long developerId);

        Task<IEnumerable<Company>> GetDevelopersAsync(IEnumerable<long> developerIds);

        Task<IEnumerable<Company>> GetPublishersAsync(IEnumerable<long> publisherIds);
    }
}