using Api_Game.Interfaces;
using Api_Game.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Game.Controllers
{
    [Route("api/[controller]")]
    public class DevelopersController : Controller
    {
        private readonly IGameService _gameService;

        public DevelopersController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET api/games
        [HttpGet("{id}")]
        public async Task<Company> Get(long id)
        {
            var developer = _gameService.GetDeveloperByIdAsync(id);
            return await developer;
        }
    }
}