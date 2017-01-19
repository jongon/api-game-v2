﻿using Api_Game.Interfaces;
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

        private readonly IClasificationTableService _clasificationTableService;

        public GamesController(
            IGameService gameService,
            ITranslatorService translatorService,
            IClasificationTableService clasificationTableService)
        {
            _clasificationTableService = clasificationTableService;
            _gameService = gameService;
            _translatorService = translatorService;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoGameName>> Get(string term, Paging paging)
        {
            var videoGames = _gameService.GetGamesAsync(term, paging);
            return await videoGames;
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public async Task<VideoGame> Get(long id)
        {
            var videoGame = await _gameService.GetGameByIdAsync(id);

            if (videoGame.Summary != null)
                videoGame.Summary = await _translatorService.TranslateToSpanishAsync(videoGame.Summary);

            if (videoGame.Storyline != null)
                videoGame.Storyline = await _translatorService.TranslateToSpanishAsync(videoGame.Storyline);

            if (videoGame.Pegi != null)
                videoGame.Pegi.Synopsis = await _translatorService.TranslateToSpanishAsync(videoGame.Pegi.Synopsis);

            if (videoGame.Tcse != null)
                videoGame.Tcse = _clasificationTableService.ConvertToTcse(videoGame.Esrb);

            return videoGame;
        }
    }
}