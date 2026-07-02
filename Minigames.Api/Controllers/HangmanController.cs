using Microsoft.AspNetCore.Mvc;
using Minigames.Application.Interfaces;
using Minigames.Application.DTOs;

namespace Minigames.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HangmanController : ControllerBase
{
    private readonly IHangmanGameService _hangmanGameService;

    public HangmanController(IHangmanGameService hangmanGameService)
    {
        _hangmanGameService = hangmanGameService;
    }

    [HttpPost("start")]
    public IActionResult StartGame()
    {
        var result = _hangmanGameService.StartGame();
        return Ok(result);
    }

    [HttpPost("guess")]
    public IActionResult GuessLetter([FromBody] HangmanGuessDto guessDto)
    {
        if (guessDto == null || string.IsNullOrWhiteSpace(guessDto.Letter))
        {
            return BadRequest("Letter is required.");
        }

        var result = _hangmanGameService.GuessLetter(guessDto.Letter);
        return Ok(result);
    }
}
