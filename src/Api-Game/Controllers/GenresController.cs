using System.Threading.Tasks;
using Api_Game.Interfaces;
using Api_Game.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Game.Controllers
{
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        // GET: /<controller>/
        private readonly IGameService _gameService;

        private readonly ITranslatorService _translatorService;

        public GenresController(
            IGameService gameService,
            ITranslatorService translatorService)
        {
            _gameService = gameService;
            _translatorService = translatorService;
        }

        // GET api/games
        [HttpGet("{id}")]
        public async Task<Genre> Get(long id)
        {
            var genre = await _gameService.GetGenreByIdAsync(id);

            genre.Name = await _translatorService.TranslateToSpanishAsync(genre.Name);

            return genre;
        }
    }
}
