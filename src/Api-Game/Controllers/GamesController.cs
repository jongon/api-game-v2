using Api_Game.Interfaces;
using Api_Game.Models;
using Api_Game.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            // TODO Image Configuration
            _gameService = gameService;
            _translatorService = translatorService;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoGameName>> Get(string term, Paging paging)
        {
            // TODO Pass Paging Parameters
            var videoGames = _gameService.GetGamesAsync(term);
            return await videoGames;
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public async Task<VideoGame> Get(long id)
        {
            var videoGame = await _gameService.GetGameByIdAsync(id);
            videoGame.Summary = await _translatorService.TranslateToSpanishAsync(videoGame.Summary);
            videoGame.Pegi.Synopsis = await _translatorService.TranslateToSpanishAsync(videoGame.Pegi.Synopsis);
            return videoGame;
        }
    }
}