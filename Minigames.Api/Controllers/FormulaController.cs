using Microsoft.AspNetCore.Mvc;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaController : ControllerBase
    {
        private readonly IFormulaGameService _formulaGameService;

        public FormulaController(IFormulaGameService formulaGameService)
        {
            _formulaGameService = formulaGameService;
        }

        [HttpGet("start/{playerName}")]
        public ActionResult<StartFormulaGameDto>StartGame(string playerName) 
        {
            var game = _formulaGameService.StartGame(playerName);
            return Ok(game);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<FormulaAnswerResultDto>>Submit(SubmitFormulaAnswerDto _answer)
        {
            return Ok(await _formulaGameService.SubmitAnswerAsync(_answer));
        }
    }
}
