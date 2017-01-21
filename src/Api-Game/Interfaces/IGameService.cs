using Api_Game.Configuration;
using Api_Game.Models;
using Api_Game.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Game.Interfaces
{
    public interface IGameService
    {
        GameApiSettings Settings { get; }

        Task<VideoGame> GetGameByIdAsync(long gameId);

        Task<IEnumerable<VideoGameExcerpt>> GetGamesAsync(string term, Paging paging);

        Task<IEnumerable<VideoGameExcerpt>> GetGamesWithExcerpt(string term, Paging paging);

        Task<Company> GetPublisherByIdAsync(long publisherId, string fields = "*");

        Task<Company> GetDeveloperByIdAsync(long developerId, string fields = "*");

        Task<Platform> GetPlatformByIdAsync(long platformId, string fields = "*");

        Task<IEnumerable<Company>> GetDevelopersAsync(IEnumerable<long> developerIds, string fields = "*");

        Task<IEnumerable<Company>> GetPublishersAsync(IEnumerable<long> publisherIds, string fields = "*");
    }
}