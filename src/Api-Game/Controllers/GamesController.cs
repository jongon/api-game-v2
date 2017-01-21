﻿using Api_Game.Interfaces;
using Api_Game.Models;
using Api_Game.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<VideoGameExcerpt>> Get(string term, Paging paging)
        {
            var videoGames = _gameService.GetGamesAsync(term, paging);
            return await videoGames;
        }

        [HttpGet("excerpt")]
        public async Task<IEnumerable<VideoGameExcerpt>> GetWithExcerpt(string term, Paging paging)
        {
            var videoGames = (await _gameService.GetGamesWithExcerpt(term, paging)).ToList();

            foreach (var videoGame in videoGames)
            {
                if (videoGame.Esrb == null) continue;
                videoGame.Tcse = _clasificationTableService.ConvertToTcse(videoGame.Esrb);
                videoGame.Esrb = _clasificationTableService.ConvertToEsrb(videoGame.Esrb);
            }

            return videoGames;
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

            if (videoGame.Genres.Any())
            {
                var genreList = videoGame.Genres as IList<dynamic> ?? videoGame.Genres.ToList();

                foreach (var t in genreList)
                {
                    t.Name = await _translatorService.TranslateToSpanishAsync(t.Name);
                }

                videoGame.Genres = genreList;
            }

            if (videoGame.Esrb == null) return videoGame;
            videoGame.Tcse = _clasificationTableService.ConvertToTcse(videoGame.Esrb);
            videoGame.Esrb = _clasificationTableService.ConvertToEsrb(videoGame.Esrb);

            return videoGame;
        }
    }
}