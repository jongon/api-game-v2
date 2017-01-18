using Api_Game.Interfaces;
using Api_Game.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Game.Controllers
{
    [Route("api/[controller]")]
    public class PublishersController : Controller
    {
        // GET: /<controller>/
        private readonly IGameService _gameService;

        public PublishersController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET api/games
        [HttpGet("{id}")]
        public async Task<Company> Get(long id)
        {
            var publisher = _gameService.GetPublisherByIdAsync(id);
            return await publisher;
        }
    }
}