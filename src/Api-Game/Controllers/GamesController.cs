using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;
using Api_Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api_Game.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly GameApiSettings _gameApiSettings;

        public GamesController(
            IOptions<GameApiSettings> apiGameSettings)
        {
            _gameApiSettings = apiGameSettings.Value;
        }

        // GET api/games
        [HttpGet]
        public async Task<IEnumerable<VideoGame>> Get()
        {
            throw new NotImplementedException();
            //return new string[] { "value1", "value2" };
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public async Task<VideoGame> Get(long id)
        {
            throw new NotImplementedException();
            //return "value";
        }
    }
}
