using DominoApi.Model;
using DominoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DominoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DominoController : ControllerBase
    {
        private ILogger<DominoController> _logger;
        private readonly DominoService _dominoService;

        public DominoController(ILogger<DominoController> logger, DominoService dominoService)
        {
            _logger = logger;
            _dominoService = dominoService;
        }

        [HttpPost]
        public async Task<ActionResult> GetResultChain([FromBody] List<Domino> dominoes)
        {
            var result = _dominoService.ObteinListChain(dominoes);
            return Ok(result.Select(domino => domino.ToString()));
        }

    }
}
