using Microsoft.AspNetCore.Mvc;
using Minigames.Application.Interfaces;
using Minigames.Application.DTOs;

namespace Minigames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HangmanController : ControllerBase
{
    private readonly IHangmanGameService _hangmanGameService;
    private readonly IPlayerService _playerService;

    public HangmanController(IHangmanGameService hangmanGameService, IPlayerService playerService)
    {
        _hangmanGameService = hangmanGameService;
        _playerService = playerService;
    }

    [HttpPost("start/{playerName}")]
    public IActionResult StartGame(string playerName)
    {
        var result = _hangmanGameService.StartGame(playerName);
        return Ok(result);
    }

    [HttpPost("guess")]
    public async Task<IActionResult> GuessLetter([FromBody] SubmitGuessDto guessDto)
    {
        if (guessDto == null || guessDto.Letter == null)
        {
            return BadRequest("Letter is required.");
        }

        var result = await _hangmanGameService.SubmitGuessAsync(guessDto);

        // If game is over, save the result to database
        if (result.IsGameOver)
        {
                await _playerService.RecordHangmanGameAsync(guessDto.PlayerName, result.IsWon);
        }

        return Ok(result);
    }
}
