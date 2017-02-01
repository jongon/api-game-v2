using Api_Game.Configuration;
using Api_Game.Interfaces;
using Api_Game.Models;
using Api_Game.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;

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

            if (videoGame.Genres.Any())
            {
                var genres = new List<Genre>();

                foreach (var genre in videoGame.Genres)
                {
                    var genreId = JsonConvert.DeserializeObject<long>(JsonConvert.SerializeObject(genre));
                    var auxGenre = await GetGenreByIdAsync(genreId, "id,name,slug");

                    genres.Add(auxGenre);
                }

                videoGame.Genres = genres;
            }

            if (!videoGame.ReleaseDates.Any()) return videoGame;

            foreach (var releaseDate in videoGame.ReleaseDates)
            {
                var platformId = JsonConvert.DeserializeObject<long>(JsonConvert.SerializeObject(releaseDate.Platform));
                releaseDate.Platform = await GetPlatformByIdAsync(platformId, "id,name");
            }

            return videoGame;
        }

        public async Task<IEnumerable<VideoGameExcerpt>> GetGamesAsync(string term, Paging paging)
        {
            paging.Limit = paging.Limit ?? 10;
            paging.Offset = paging.Offset ?? 0;
            paging.OrderParam = paging.OrderParam ?? "popularity";

            var orderString = paging.OrderAsc ? "asc" : "desc";

            var parameters = new Dictionary<string, string>
            {
                { "fields", "name" },
                { "limit" , paging.Limit.ToString() },
                { "offset", paging.Offset.ToString() },
                { "order", $"{paging.OrderParam}:{orderString}" },
                { "search", term }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Games"]}/";
            var result = await GameHttpClient.GetAsync<VideoGameExcerpt>(uri, Settings.Headers, parameters);
            return result;
        }

        public async Task<IEnumerable<VideoGameExcerpt>> GetGamesWithExcerpt(string term, Paging paging)
        {
            Func<IEnumerable<dynamic>, IList<long>> publisherParser =
                x => JsonConvert.DeserializeObject<IList<long>>(JsonConvert.SerializeObject(x));

            paging.Limit = paging.Limit ?? 10;
            paging.Offset = paging.Offset ?? 0;
            paging.OrderParam = paging.OrderParam ?? "popularity";

            var orderString = paging.OrderAsc ? "asc" : "desc";

            var parameters = new Dictionary<string, string>
            {
                { "fields", "name,cover,publishers,esrb" },
                { "limit" , paging.Limit.ToString() },
                { "offset", paging.Offset.ToString() },
                { "order", $"{paging.OrderParam}:{orderString}" },
                { "search", term }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Games"]}/";
            var results = await GameHttpClient.GetAsync<VideoGameExcerpt>(uri, Settings.Headers, parameters);

            var tasks = new List<Task<VideoGameExcerpt>>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var result in results)
            {
                var task =
                    Task.Run(() => publisherParser(result.Publishers))
                        .ContinueWith(publisherIds => GetPublishersAsync(publisherIds.Result, "id,name").Result)
                        .ContinueWith(p =>
                        {
                            result.Publishers = p.Result;
                            return result;
                        });

                tasks.Add(task);
            }

            return await Task.WhenAll(tasks);
        }

        public async Task<Company> GetPublisherByIdAsync(long publisherId, string fields = "*")
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", fields }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Publishers"]}/{publisherId}/";
            var result = await GameHttpClient.GetAsync<Company>(uri, Settings.Headers, parameters);
            return result.FirstOrDefault();
        }

        public async Task<Company> GetDeveloperByIdAsync(long developerId, string fields = "*")
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", fields }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Developers"]}/{developerId}/";
            var result = GameHttpClient.GetAsync<Company>(uri, Settings.Headers, parameters);
            return (await result).FirstOrDefault();
        }

        public async Task<Platform> GetPlatformByIdAsync(long platformId, string fields = "*")
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", fields }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Platforms"]}/{platformId}/";
            var result = GameHttpClient.GetAsync<Platform>(uri, Settings.Headers, parameters);
            return (await result).FirstOrDefault();
        }

        public async Task<Genre> GetGenreByIdAsync(long genreId, string fields = "*")
        {
            var parameters = new Dictionary<string, string>
            {
                { "fields", fields }
            };

            var uri = $"{Settings.ApiUri}/{Settings.Routes["Genres"]}/{genreId}/";
            var result = GameHttpClient.GetAsync<Genre>(uri, Settings.Headers, parameters);
            return (await result).FirstOrDefault();
        }

        public async Task<IEnumerable<Company>> GetDevelopersAsync(IEnumerable<long> developerIds, string fields = "*")
        {
            var tasks = developerIds.Select(developerId => GetDeveloperByIdAsync(developerId, fields));

            var developers = await Task.WhenAll(tasks);

            return developers;
        }

        public async Task<IEnumerable<Company>> GetPublishersAsync(IEnumerable<long> publisherIds, string fields = "*")
        {
            var tasks = publisherIds.Select(publisherId => GetPublisherByIdAsync(publisherId, fields));

            var publishers = await Task.WhenAll(tasks);

            return publishers;
        }
    }
}