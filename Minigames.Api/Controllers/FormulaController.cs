using Microsoft.AspNetCore.Mvc;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormulaController (IFormulaGameService _formulaGameService, IPlayerService _playerService) : ControllerBase
{
    [HttpGet("start/{playerName}")]
    public ActionResult<StartFormulaGameDto> StartGame(string playerName) 
    {
        var game = _formulaGameService.StartGame(playerName);
        return Ok(game);
    }

    [HttpPost("submit")]
    public async Task<ActionResult<FormulaAnswerResultDto>> Submit(SubmitFormulaAnswerDto _answer)
    {

            var result = await _formulaGameService.SubmitFormulaAnswerAsync(_answer);

            return Ok(result);
    }
}
