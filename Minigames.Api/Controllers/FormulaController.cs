using Microsoft.AspNetCore.Mvc;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormulaController : ControllerBase
{
    private readonly IFormulaGameService _formulaGameService;
    private readonly IPlayerService _playerService;

    public FormulaController(IFormulaGameService formulaGameService, IPlayerService playerService)
    {
        _formulaGameService = formulaGameService;
        _playerService = playerService;
    }

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

        // Record formula game result
        try
        {
            await _playerService.RecordFormulaGameAsync(_answer.PlayerName, result.Difference);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error recording formula game: {ex.Message}");
        }

        return Ok(result);
    }
}
