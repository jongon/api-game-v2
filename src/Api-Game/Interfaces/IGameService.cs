using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Models;

namespace Api_Game.Interfaces
{
    public interface IGameService
    {
        Task<VideoGame> GetGameByIdAsync(long id);

        Task<IEnumerable<VideoGame>> GetGamesAsync(string term);
    }
}
