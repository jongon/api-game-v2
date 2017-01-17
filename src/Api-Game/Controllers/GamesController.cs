using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Game.Configuration;
using Api_Game.Interfaces;
using Api_Game.Models;
using Api_Game.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api_Game.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        private readonly ITranslatorService _translatorService;

        public GamesController(
            IGameService gameService,
            ITranslatorService translatorService)
        {
            _gameService = gameService;
            _translatorService = translatorService;
        }

        // GET api/games
        [HttpGet]
        public async Task<IEnumerable<VideoGame>> Get(string term)
        {
            var videoGames = _gameService.GetGamesAsync(term);
            return await videoGames;
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public async Task<VideoGame> Get(long id)
        {
            var videoGame = await _gameService.GetGameByIdAsync(id);
            videoGame.Summary = await _translatorService.TranslateToSpanishAsync(videoGame.Summary);
            return videoGame;
        }
    }
}
